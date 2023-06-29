//#undef DEBUG
//--------------------------------------------------------------------------
// <summary>
//   
// </summary>
// <copyright file="AudioPlayer.cs" company="Chuck Hill">
// Copyright (c) 2020 Chuck Hill.
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public License
// as published by the Free Software Foundation; either version 2.1
// of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// The GNU Lesser General Public License can be viewed at
// http://www.opensource.org/licenses/lgpl-license.php. If
// you unfamiliar with this license or have questions about
// it, here is an http://www.gnu.org/licenses/gpl-faq.html.
//
// All code and executables are provided "as is" with no warranty
// either express or implied. The author accepts no liability for
// any damage or loss of business that this product may cause.
// </copyright>
// <repository>https://github.com/ChuckHill2/AudioPlayer</repository>
// <author>Chuck Hill</author>
//--------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

// =======================================================================
// This file has NO external dependencies as such this file may be reused anywhere.
// =======================================================================

namespace TriviaClientApp
{
    /// <summary>
    /// The status of the notification event.
    /// </summary>
    [Flags] //Are these really flags?
    public enum MCINotify
    {
        /// <summary>
        /// The playing sound has ran to completion.
        /// </summary>
        Successful = 0x0001,

        /// <summary>
        /// Internal state change. For our purposes, this is never received.
        /// </summary>
        Superseded = 0x0002,

        /// <summary>
        /// The playing sound as been Stopped or Closed mid-play.
        /// </summary>
        Aborted = 0x0004,

        /// <summary>
        /// Sound corrupted during play?? For our purposes, this is never received.
        /// </summary>
        Failure = 0x0008
    }

    /// <summary>
    /// Response from MediaState()
    /// </summary>
    public enum MCIState
    {
        /// <summary>
        /// Sound device is not in use and clip is ready to be opened.
        /// </summary>
        Closed,

        /// <summary>
        /// The playing sound is paused. And may be resumed from where it left off.
        /// </summary>
        Paused,

        /// <summary>
        /// The sound is playing the clip and will stay in this state until it is explicitly stopped or closed.
        /// Note: The PlayStateChanged event will fire when the playing has stopped naturally or when explicitly stopped.
        /// </summary>
        Playing,

        /// <summary>
        /// Sound file has been opened/loaded ready to play. The sound file stays loaded in the device until Closed.
        /// </summary>
        Stopped,

        /// <summary>Not applicable for this audio device.</summary>
        NotReady,
        /// <summary>Not applicable for this audio device.</summary>
        Open,
        /// <summary>Not applicable for this audio device.</summary>
        Parked,
        /// <summary>Not applicable for this audio device.</summary>
        Recording,
        /// <summary>Not applicable for this audio device.</summary>
        Seeking,
        /// <summary>Not applicable for this audio device.</summary>
        Unknown
    }

    /// <summary>
    /// A friendly interface to the audio device of the WinMM dll.
    /// This is NOT thread-safe. In addition, it must run on the same thread as the application Forms UI. This is a constraint of WinMM itself.
    /// However multiple instances of AudioPlayer may be allowed (not tested!).
    /// </summary>
    public class AudioPlayer : NativeWindow, IDisposable
    {
        #region Win32

        /// <summary>
        /// Sends a command string to an MCI device. The device that the command is sent to is specified in the command string.
        /// </summary>
        /// <param name="strCommand">
        ///    Pointer to a null-terminated string that specifies an MCI command string.
        ///    <see cref="https://learn.microsoft.com/en-us/windows/win32/multimedia/multimedia-command-strings"/>
        /// </param>
        /// <param name="lpszReturnString">Pointer to a buffer that receives return information. If no return information is needed, this parameter can be NULL.</param>
        /// <param name="cchReturn">Size, in characters, of the return buffer specified by the lpszReturnString parameter.</param>
        /// <param name="hwndCallback">Handle to a callback window if the "notify" flag was specified in the command string.</param>
        /// <returns>
        ///    Returns zero if successful or an error otherwise. The low-order word of the returned 
        ///    DWORD value contains the error return value. If the error is device-specific, the 
        ///    high-order word of the return value is the driver identifier; otherwise, the high-
        ///    order word is zero. For a list of possible error values, see MCIERR Return Values.
        ///    <see cref="https://learn.microsoft.com/en-us/windows/win32/multimedia/mcierr-return-values" />
        ///    To retrieve a text description of return values, pass the return value to the 
        /// mciGetErrorString function.        
        /// </returns>
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand, StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);

        /// <summary>
        /// Retrieves a string that describes the specified MCI error code.
        /// </summary>
        /// <param name="fdwError">Error code returned by the mciSendCommand or mciSendString function.</param>
        /// <param name="lpszErrorText">Buffer that receives a null-terminated string describing the specified error.</param>
        /// <param name="cchErrorText">Length of the buffer, in characters, pointed to by the lpszErrorText parameter. Each string that MCI returns, whether data or an error description, can be a maximum of 128 characters.</param>
        /// <returns>TRUE if successful or FALSE if the error code is not known.</returns>
        [DllImport("winmm.dll")]
        private static extern bool mciGetErrorString(int fdwError, StringBuilder lpszErrorText, int cchErrorText);

        /// <summary>
        /// Hi-level MCI command. 
        /// Handles the notification setup. 
        /// Writes error messages to the output debug window. 
        /// Writes trace messages to the output debug window.
        /// </summary>
        /// <param name="command">Command to send to the winmm audio device.</param>
        /// <param name="hasReturnValue">True to capture response.</param>
        /// <returns>if hasReturnValue==true the response is returned else an empty string is returned. If an error occurs, null is returned.</returns>
        private string MciSendCommand(string command)
        {
            InitializeNotificationHandle();
            var state = State();
            if (state == MCIState.Closed && !command.StartsWith("open")) return string.Empty;

            IntPtr hwndCallback = IntPtr.Zero;

            if (this.Handle != IntPtr.Zero && command.EndsWith(" notify")) hwndCallback = this.Handle;

            int status = mciSendString(command, ReturnValue, 128, hwndCallback);
            var retval = ReturnValue.ToString();

            if (status != 0)
            {
                var emsg = MciErrorString(status);
                this.Error?.Invoke(this, new ErrorEventArgs(command, status, emsg));
                LastError = $"{nameof(AudioPlayer)} ERROR: \"{command}\": {emsg}";
                Debug.WriteLine(LastError);
                return null;
            }
            else Debug.WriteLine($"{nameof(AudioPlayer)}: State={this.State()}, Command=\"{command}\"" +
                (command.StartsWith("open") ? string.Empty : $", File=\"{Path.GetFileName(LoadedFile())}\"") +
                (retval.Length == 0 ? string.Empty : $", Response=\"{retval}\"") );

            return retval;
        }

        private readonly StringBuilder ReturnValue = new StringBuilder(128);  //predefined for reuse.

        private string MciErrorString(int errorCode)
        {
            if (mciGetErrorString(errorCode, ReturnValue, 128)) return ReturnValue.ToString();
            return "0x" + errorCode.ToString("X8");
        }
        #endregion

        private Form Owner = null;
        private Control NotificationHandlerControl = null;
        private readonly string MediaAlias;

        private string CurrentFile = null;
        private int CurrentAudioLength = 0;
        private string PreviousFile = null;

        #region Events
        public class NotificationEventArgs : EventArgs
        {
            public readonly MCINotify Status;
            public readonly MCIState State;
            public readonly string Filename;
            public NotificationEventArgs(MCINotify status, MCIState state, string filename)
            {
                Status = status;
                State = state;
                Filename = filename;
            }
        }
        public class ErrorEventArgs : EventArgs
        {
            /// <summary>
            /// MCI command that caused the error
            /// </summary>
            public readonly string Command;
            /// <summary>
            /// The error code returned from mciSendString() 
            /// </summary>
            public readonly int ErrorCode;
            /// <summary>
            /// The translated error message.
            /// </summary>
            public readonly string ErrorMessage;
            public ErrorEventArgs(string command, int errorCode, string errorMessage)
            {
                this.Command = command;
                this.ErrorCode = errorCode;
                this.ErrorMessage = errorMessage;
            }
        }
        public class VolumeChangedEventArgs : EventArgs
        {
            public readonly int?  LeftVolume;
            public readonly int?  RightVolume;
            public readonly int?  StereoBalance;
            public readonly int?  MasterVolume;
            public readonly int?  Bass;
            public readonly int?  Treble;
            public readonly bool? Mute;
            public readonly bool? MuteLeft;
            public readonly bool? MuteRight;
            public readonly int? PlaySpeed;

            public VolumeChangedEventArgs(
                int?  leftVolume = null,
                int? rightVolume = null,
                int? stereoBalance = null,
                int? masterVolume = null,
                int? bass = null,
                int? treble = null,
                bool? mute = null,
                bool? muteLeft = null,
                bool? muteRight = null,
                int? playspeed = null
                )
            {
                LeftVolume = leftVolume;
                RightVolume = rightVolume;
                StereoBalance = stereoBalance;
                MasterVolume = masterVolume;
                Bass = bass;
                Treble = treble;
                Mute = mute;
                MuteLeft = muteLeft;
                MuteRight = muteRight;
                PlaySpeed = playspeed;
            }
        }

        public delegate void NotificationEventHandler(AudioPlayer sender, NotificationEventArgs e);
        public delegate void ErrorEventHandler(AudioPlayer sender, ErrorEventArgs e);
        public delegate void VolumeChangedEventHandler(AudioPlayer sender, VolumeChangedEventArgs e);

        public event NotificationEventHandler PlayStateChanged;
        public event ErrorEventHandler Error;
        public event VolumeChangedEventHandler VolumeChanged;
        #endregion Events

        /// <summary>
        /// AudioPlayer Constructor.
        /// This is NOT thread-safe. In addition, this must run on the same thread as the application Forms UI. This is a constraint of WinMM itself.
        /// </summary>
        /// <param name="owner">The owner of our child control that will be our notification message pump. If null, it uses the top-level form as the owner.</param>
        public AudioPlayer(Form owner)
        {
            Owner = owner;
            //Create a unique alias to allow multiple instances to run and not interfere with each other.
            MediaAlias = "X"+((uint)((DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond) & 0xFFFFFFFF)).ToString("X8");
        }
        private AudioPlayer() { } //Owner is *really* required.

        private bool Initialized = false;
        private void InitializeNotificationHandle()
        {
            // We initialize as late as possible on first use as the owner handle may not have been initialized yet.
            // Besides, if this AudioPlayer is never used, then we don't waste time and resources.
            if (Initialized) return;
            Initialized = true;

            if (Owner == null) Owner = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
            if (Owner != null) Owner.FormClosed += Owner_FormClosed;

            // Sole purpose of this control is to recieve the notification window message, thus this control is never busy.
            // The only messages  this control recieves is WM_Create, MM_MCINOTIFY, and WM_DESTROY.
            // This is better than inserting an intercept WndProc into the very busy owning form while ignoring 99.999% of the messages.
            NotificationHandlerControl = new Control(Owner as Control, nameof(AudioPlayer) + " Notifications", 10, 10, 10, 10);
            NotificationHandlerControl.Name = nameof(AudioPlayer) + "NotificationsCtrl"; //for debugging...
            NotificationHandlerControl.Visible = false; // Default Control.Visible==true
            NotificationHandlerControl.CreateControl(); // Now, create the underlying handle...

            base.AssignHandle(NotificationHandlerControl.Handle);
        }

        private void Owner_FormClosed(object sender, FormClosedEventArgs e) => this.Dispose();

        /// <summary>
        /// Dispose this instance of AudioPlayer
        /// </summary>
        public void Dispose()
        {
            Debug.WriteLine($"AudioPlayer.Dispose handler exists={NotificationHandlerControl != null}");
            if (NotificationHandlerControl != null)
            {
                if (Owner != null) Owner.FormClosed -= Owner_FormClosed;
                this.ReleaseHandle();
                NotificationHandlerControl.Dispose();
                NotificationHandlerControl = null;
                //Cleanup any temp files created by Open(Stream) or Open(byte[])
                foreach(var fn in StreamFiles.Values)
                {
                    if (File.Exists(fn)) File.Delete(fn);
                }
                StreamFiles.Clear();
            }
        }
        ~AudioPlayer() => Dispose();
        

        //The notification handler.
        protected override void WndProc(ref Message m)
        {
            const int MM_MCINOTIFY = 0x03B9;
            const int WM_DESTROY = 0x0002;

            if (m.Msg == MM_MCINOTIFY)
            {
                //int deviceId = (int)m.LParam;
                MCIState state = this.State();
                var fn = state == MCIState.Closed ? PreviousFile : CurrentFile;
                var status = (MCINotify)(int)m.WParam;
                Debug.WriteLine($"MM_MCINOTIFY({status}): State={state}, \"{Path.GetFileName(fn)}\"");

                //Call this before this.Stop() so caller may query sender for further details. 
                PlayStateChanged?.Invoke(this, new NotificationEventArgs(status,state,fn));
            }
            else if (m.Msg == WM_DESTROY)
            {
                Dispose();
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Contains the last mciSendString formatted error message or empty if no error occured since it was last cleared.
        /// Also see event 'Error' for realtime error responses
        /// </summary>
        public string LastError { get; private set; } = string.Empty;
        /// <summary>
        /// Clear the last error message. e.g. sets it to empty.
        /// </summary>
        public void LastErrorClear() => LastError = string.Empty;

        /// <summary>
        /// Stops and closes the sound buffer.
        /// </summary>
        public void Close()
        {
            Stop();

            if (this.State()== MCIState.Stopped)
            {
                MciSendCommand($"close {MediaAlias}"); //"close all" - closes all loaded files in all instances within this application. 
                if (CurrentFile != null)
                {
                    PreviousFile = CurrentFile;
                    CurrentFile = null;
                    CurrentAudioLength = 0;
                }
            }
        }

        /// <summary>
        /// Opens the sound buffer with the specified sound file, stream, or byte array.
        /// It stops/closes the previous soundbuffer.
        /// </summary>
        /// <param name="soundObject">filename, stream, or byte array to load into sound buffer</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="soundObject" /> is <see langword="null" />.</exception>
        /// <exception cref="T:System.InvalidCastException">Typeof <paramref name="soundObject" /> is not  supported. Must be <see cref="T:System.String" />n <see cref="T:System.IO.Stream" />, or <see cref="T:System.Byte[]" />>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="soundObject" /> length must be greater than zero.</exception>
        /// <returns>True if sound object was successfully opened.</returns>
        public bool Open(object soundObject)
        {
            if (soundObject == null) throw new ArgumentNullException(nameof(soundObject));
            else if (soundObject is string) return Open((string)soundObject);
            else if (soundObject is Stream) return Open ((Stream)soundObject);
            else if (soundObject is byte[]) return Open ((byte[])soundObject);
            else throw new InvalidCastException($"{soundObject.GetType().Name} is not supported. Must be of type String, Stream, or Byte[]");
        }

        //Placeholder for all the audio streams/bytes saved to temp files for reuse.
        private readonly Dictionary<int, string> StreamFiles = new Dictionary<int, string>();
        private bool Open(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (fileName.Length == 0) throw new ArgumentOutOfRangeException(nameof(fileName), 0, "Length must be greater than zero.");

            Close();
            if (MciSendCommand($"open \"{fileName}\" type mpegvideo alias {MediaAlias}") != null)
            {
                RestoreVolume();
                CurrentFile = fileName;
                MciSendCommand($"set {MediaAlias} time format milliseconds");
                CurrentAudioLength = 0; //clear cached audio length
                this.AudioLength(); //set new cached audio length.
                return true;
            }
            return false;
        }
        private bool Open(Stream stream)
        {
            //WinMM *requires* a filename so we dump the contents into a temp files, reuse them as necessary, and finally delete them upon AudioPlayer.Dispose().
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (stream.Length == 0) throw new ArgumentOutOfRangeException(nameof(stream), 0, "Length must be greater than zero.");

            int key = (int)stream.Length;
            if (!StreamFiles.TryGetValue(key,out string fileName) || !File.Exists(fileName))
            {
                fileName = GetTempMediaFile();
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 4096, FileOptions.None))
                {
                    stream.CopyTo(fs);
                }
                StreamFiles[key] = fileName;
            }

            return this.Open(fileName);
        }
        private bool Open(byte[] bytes)
        {
            //WinMM *requires* a filename so we dump the contents into a temp files, reuse them as necessary, and finally delete them upon AudioPlayer.Dispose().
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0) throw new ArgumentOutOfRangeException(nameof(bytes), 0, "Length must be greater than zero.");

            int key = (int)bytes.Length;
            if (!StreamFiles.TryGetValue(key, out string fileName) || !File.Exists(fileName))
            {
                fileName = GetTempMediaFile();
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 4096, FileOptions.None))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                StreamFiles[key] = fileName;
            }

            return this.Open(fileName);
        }
        private string GetTempMediaFile()
        {
            // Create a unique temporary media file name.
            // We don't use Path.GetTempFileName() because we want a filename unique to 
            // AudioPlayer so if any files are somehow left over they can be easily recognizable in 
            // the folder %LocalAppData%\Temp\ or C:\Users\[loginName]\AppData\Local\Temp\.
            // The following is not thread-safe but it is really unique across AudioPlayer Instances.

            string fileName;
            var dirprefix = Path.GetTempPath() + nameof(AudioPlayer) + MediaAlias;
            int index = 0;
            do
            {
                fileName = dirprefix + (index++).ToString("00") + ".snd";
            } while (File.Exists(fileName));
            //File.Create(fileName).Dispose(); //not needed to lock name.
            return fileName;
        }

        /// <summary>
        /// Play the sound opened on this device at the previous sound level. 
        /// </summary>
        /// <param name="continuous">Play this sound in a continuous loop until Stopped or Closed.</param>
        public void Play(bool continuous) => Play(continuous, -1);
        /// <summary>
        /// Play the sound opened on this device at the specified sound level. 
        /// </summary>
        /// <param name="continuous">Play this sound in a continuous loop until Stopped or Closed.</param>
        /// <param name="volume">The volume level to play this sound at. Valid range is 0-1000.</param>
        public void Play(bool continuous, int volume)
        {
            if (this.State() == MCIState.Stopped)
            {
                if (volume !=-1) this.MasterVolume = volume;
                MciSendCommand($"play {MediaAlias}{(continuous ? " repeat" : "")} notify");
            }
        }

        /// <summary>
        /// Stops the sound from playing.
        /// </summary>
        public void Stop()
        {
            var state = this.State();
            if (state == MCIState.Playing || state == MCIState.Paused)
            {
                MciSendCommand($"stop {MediaAlias}");
            }
        }

        /// <summary>
        /// Pauses the playing sound
        /// </summary>
        public void Pause()
        {
            var state = this.State();
            if (state == MCIState.Playing || state != MCIState.Paused)
            {
                MciSendCommand($"pause {MediaAlias}");
            }
        }

        /// <summary>
        /// Resumes the sound from where it was previously paused.
        /// </summary>
        public void Resume()
        {
            if (this.State() == MCIState.Paused)
            {
                MciSendCommand($"resume {MediaAlias}");
            }
        }

        /// <summary>
        /// Gets the current state of the this AudioPlayer instance.
        /// </summary>
        /// <returns></returns>
        public MCIState State()
        {
            //Direct use of mciSendString is used here to avoid recursion in MciSendCommand()
            if (StateCommand==null) StateCommand = $"status {MediaAlias} mode";
            mciSendString(StateCommand, ReturnValue, 128, IntPtr.Zero);
            switch (ReturnValue.ToString())
            {
                case "":          return MCIState.Closed;
                case "paused":    return MCIState.Paused;
                case "playing":   return MCIState.Playing;
                case "stopped":   return MCIState.Stopped;
                case "not ready": return MCIState.NotReady;
                //Not all devices can recieve the following...
                case "open":      return MCIState.Open;
                case "parked":    return MCIState.Parked;
                case "recording": return MCIState.Recording;
                case "seeking":   return MCIState.Seeking;
                default:          return MCIState.Unknown;
            }
        }
        private string StateCommand = null;

        #region Volume State
        // The volume state is maintained only  for the duration of a single opened file.
        // We want to maintain it globally for the life of the AudioPlayer object.
        // This means we have to save it upon play completion and restore upon the next open.
        // Note: the full range is 0 to 1000 where 1000 is the default.

        public const int VolumeMinValue = 0;
        public const int VolumeMaxValue = 1000;
        public const int BalanceMinValue = -1000;
        public const int BalanceMaxValue = 1000;
        public const int BalanceCentered = 0;
        public const int SpeedMinValue = 3;
        public const int SpeedNormal = 1000;
        public const int SpeedMaxValue = 4353;

        private int _volumeLeft = VolumeMaxValue;
        private int _volumeRight = VolumeMaxValue;
        private int _stereoBalance = BalanceCentered;
        private int _volumeMaster = VolumeMaxValue;
        private int _volumeBass = VolumeMaxValue;
        private int _volumeTreble = VolumeMaxValue;
        private int _playspeed = SpeedNormal;
        private bool _volumeMutedLeft = false;
        private bool _volumeMutedRight = false;
        private bool ForceUpdateValues = false;
        private void RestoreVolume()
        {
            ForceUpdateValues = true;
            LeftVolume = _volumeLeft;
            RightVolume = _volumeRight;
            //StereoBalance = _stereoBalance;  //derived from LeftVolume/RightVolume
            //MasterVolume = _volumeMaster;  //derived from LeftVolume/RightVolume
            Bass = _volumeBass;
            Treble = _volumeTreble;
            PlaySpeed = _playspeed;
            //Mute = _volumeMuted;   //derived from LeftVolume/RightVolume
            MuteLeft = _volumeMutedLeft;
            MuteRight = _volumeMutedRight;
            ForceUpdateValues = false;
        }
        #endregion Volume State

        public int LeftVolume
        {
            get => _volumeLeft;
            set
            {
                value = FitRange(value, VolumeMinValue, VolumeMaxValue);
                if (_volumeLeft == value && !ForceUpdateValues) return;
                _volumeLeft = value;
                MciSendCommand($"setaudio {MediaAlias} left volume to {value}");

                _volumeMaster = _volumeLeft > _volumeRight ? _volumeLeft : _volumeRight;
                if (_volumeLeft > _volumeRight)
                    _stereoBalance = -(int)(_volumeRight / (_volumeMaster / (double)VolumeMaxValue) - VolumeMaxValue + 0.5);
                else
                    _stereoBalance = (int)(_volumeLeft / (_volumeMaster / (double)VolumeMaxValue) - VolumeMaxValue + 0.5);

                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(leftVolume: _volumeLeft, masterVolume: _volumeMaster, stereoBalance: _stereoBalance));
            }
        }
        public int RightVolume
        {
            get => _volumeRight;
            set
            {
                value = FitRange(value, VolumeMinValue, VolumeMaxValue);
                if (_volumeRight == value && !ForceUpdateValues) return;
                _volumeRight = value;
                MciSendCommand($"setaudio {MediaAlias} right volume to {value}");

                _volumeMaster = _volumeLeft > _volumeRight ? _volumeLeft : _volumeRight;
                if (_volumeLeft > _volumeRight)
                    _stereoBalance = -(int)(_volumeRight / (_volumeMaster / (double)VolumeMaxValue) - VolumeMaxValue + 0.5);
                else
                    _stereoBalance = (int)(_volumeLeft / (_volumeMaster / (double)VolumeMaxValue) - VolumeMaxValue + 0.5);

                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(rightVolume: _volumeRight, masterVolume: _volumeMaster, stereoBalance: _stereoBalance));
            }
        }
        public int StereoBalance
        {
            get => _stereoBalance;
            set
            {
                value = FitRange(value, BalanceMinValue, BalanceMaxValue);
                if (value == _stereoBalance && !ForceUpdateValues) return;
                _stereoBalance = value;

                if (value < 0)
                {
                    _volumeLeft  = _volumeMaster;
                    _volumeRight = (int)(((VolumeMaxValue + value) * (_volumeMaster / (double)VolumeMaxValue)) + 0.5);
                }
                else
                {
                    _volumeLeft  = (int)(((VolumeMaxValue - value) * (_volumeMaster / (double)VolumeMaxValue)) + 0.5);
                    _volumeRight = _volumeMaster;
                }

                MciSendCommand($"setaudio {MediaAlias} left volume to {_volumeLeft}");
                MciSendCommand($"setaudio {MediaAlias} right volume to {_volumeRight}");
                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(leftVolume: _volumeLeft, rightVolume: _volumeRight, stereoBalance: _stereoBalance));
            }
        }

        public int MasterVolume
        {
            get => _volumeMaster;
            set
            {
                value = FitRange(value, VolumeMinValue, VolumeMaxValue);
                if (value == _volumeMaster && !ForceUpdateValues) return;
                _volumeMaster = value;

                if (_stereoBalance < 0)
                {
                    _volumeLeft = _volumeMaster;
                    _volumeRight = (int)(((VolumeMaxValue + _stereoBalance) * (_volumeMaster / (double)VolumeMaxValue)) + 0.5);
                }
                else
                {
                    _volumeLeft = (int)(((VolumeMaxValue - _stereoBalance) * (_volumeMaster / (double)VolumeMaxValue)) + 0.5);
                    _volumeRight = _volumeMaster;
                }

                MciSendCommand($"setaudio {MediaAlias} left volume to {_volumeLeft}");
                MciSendCommand($"setaudio {MediaAlias} right volume to {_volumeRight}");
                //MciSendCommand($"setaudio {MediaAlias} volume to {value}");  //sets both channels to SAME value!
                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(masterVolume: _volumeMaster, leftVolume: _volumeLeft, rightVolume: _volumeRight));
            }
        }

        public bool Mute
        {
            get => MuteLeft && MuteRight;
            set
            {
                // (1) Do not use "setaudio MediaAlias [off|on]" as it sets the state irrespective of the mute state for each stereo channel.
                // (2) Do not set MuteLeft & MuteRight properties here as it will trigger 2-3 VolumeChanged events.
                // (3) Go thru these 2 mute state tests in order to set the VolumeChanged event intelligently.

                bool? ml = null;
                bool? mr = null;
                if (MuteLeft != value)
                {
                    ml = value;
                    _volumeMutedLeft = value;
                    MciSendCommand($"setaudio {MediaAlias} left {(value ? "off" : "on")}");
                }
                if (MuteRight != value)
                {
                    mr = value;
                    _volumeMutedRight = value;
                    MciSendCommand($"setaudio {MediaAlias} right {(value ? "off" : "on")}");
                }
                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(muteLeft: ml, muteRight: mr, mute: value));
            }
        }
        public bool MuteLeft
        {
            get => _volumeMutedLeft;
            set
            {
                if (_volumeMutedLeft == value && !ForceUpdateValues) return;
                _volumeMutedLeft = value;
                MciSendCommand($"setaudio {MediaAlias} left {(value ? "off" : "on")}");
                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(muteLeft: value, mute:Mute));
            }
        }
        public bool MuteRight
        {
            get => _volumeMutedRight;
            set
            {
                if (_volumeMutedRight == value && !ForceUpdateValues) return;
                _volumeMutedRight = value;
                MciSendCommand($"setaudio {MediaAlias} right {(value ? "off" : "on")}");
                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(muteRight: value, mute: Mute));
            }
        }

        // Don't know why all the other public code regarding mciSendString media type MPEGVideo 
        // implements Bass and Treble when in fact, it is not supported! However, if you really want to 
        // try it out, add the conditional compilation symbol HAS_BASS_TREBLE to the project build.
#if HAS_BASS_TREBLE
         public int Bass
         {
             get => _volumeBass;
             set
             {
                 value = FitRange(value, VolumeMinValue, VolumeMaxValue);
                 if (value == _volumeBass && !ForceUpdateValues) return;
                 _volumeBass = value;
                 MciSendCommand($"setaudio {MediaAlias} bass to {value}");
                 VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(bass: value));
             }
         }

         public int Treble
         {
             get => _volumeTreble;
             set
             {
                 value = FitRange(value, VolumeMinValue, VolumeMaxValue);
                 if (value == _volumeTreble && !ForceUpdateValues) return;
                 _volumeTreble = value;
                 var st = State();
                 MciSendCommand($"setaudio {MediaAlias} treble to {value}");
                 VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(treble: value));
             }
         }
#else
        private int Bass;   //simulated dummy property
        private int Treble; //simulated dummy property
#endif

        public int PlaySpeed
        {
            get => _playspeed;
            set
            {
                value = FitRange(value, SpeedMinValue, SpeedMaxValue);
                if (value == _playspeed && !ForceUpdateValues) return;
                _playspeed = value;
                MciSendCommand($"set {MediaAlias} speed {value}");
                VolumeChanged?.Invoke(this, new VolumeChangedEventArgs(playspeed: value));
            }
        }

        /// <summary>
        /// Get the file loaded with Open(). Returns empty if the device is closed.
        /// </summary>
        public string LoadedFile()
        {
            mciSendString($"info {MediaAlias} file", ReturnValue, 128, IntPtr.Zero);
            return ReturnValue.ToString();
        }

        /// <summary>
        /// The length of the open/loaded sound file in milliseconds.
        /// </summary>
        public int AudioLength()
        {
            if (CurrentAudioLength == 0)
                CurrentAudioLength = int.TryParse(MciSendCommand($"status {MediaAlias} length"), out var i) ? i : 0;
            return CurrentAudioLength;
        }

        /// <summary>
        /// Position of the playing sound in milliseconds. May be used for fast-forward or rewind. 
        /// Use a position between 0 and this.AudioLength(). For performance, boundry checking is NOT performed.
        /// Developers Note: Int64 is unecessary as Int32 max value in milliseconds is 24.9 days!
        /// </summary>
        public int Position
        {
            //Because this may be used very frequently (for a live trackbar?), mciSendString() is used directly.
            get
            {
                if (GetPositionCmd == null) GetPositionCmd = $"status {MediaAlias} position";
                mciSendString(GetPositionCmd, PositionSB, 128, IntPtr.Zero);
                return int.TryParse(PositionSB.ToString(), out var i) ? i : 0;
            }
            set
            {
                if (State()==MCIState.Playing)
                    MciSendCommand($"play {MediaAlias} from {value}");
                else
                    MciSendCommand($"seek {MediaAlias} to {value}");
            }
        }
        private StringBuilder PositionSB = new StringBuilder(128);
        private string GetPositionCmd = null;

        private static int FitRange(int value, int minvalue, int maxvalue) => value < minvalue ? minvalue : (value > maxvalue ? maxvalue : value);

        /// <summary>
        /// List of file extensions supported by this audio player. This is retrieved from the registry.
        /// </summary>
        /// <returns>list of extensions or an empty array upon error.</returns>
        public static string[] SupportedTypes()
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Multimedia\WMPlayer\Extensions"))
                {
                    return key.GetSubKeyNames().Where(name =>
                    {
                        using (var subkey = key.OpenSubKey(name))
                        {
                            string MCIHandler = subkey.GetValue("MCIHandler", string.Empty) as string;
                            string PerceivedType = subkey.GetValue("PerceivedType", string.Empty) as string;
                            return (MCIHandler.Equals("MPEGVideo", StringComparison.OrdinalIgnoreCase)
                                  && PerceivedType.Equals("audio", StringComparison.OrdinalIgnoreCase));
                        }
                    }).OrderBy(m => m).ToArray();
                }
            }
            catch
            {
                return new string[0];
            }
        }

        /// <summary>
        /// Get the media file duration in ms.
        /// This is NOT thread-safe. In addition, it must run on the same thread as the application Forms UI.
        /// Warning: MediaDuration() and WaveDuration() results may be mismatched by 1ms due to rounding.
        /// </summary>
        /// <param name="mediafile"></param>
        /// <returns>Duration in milliseconds or 0 upon error.</returns>
        public static int MediaDuration(string mediafile)
        {
            if (mediafile == null) throw new ArgumentNullException(nameof(mediafile));
            var alias = "MD" + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString("X8");
            if (mciSendString($"open \"{mediafile}\" type mpegvideo alias {alias}", null, 0, IntPtr.Zero) == 0)
            {
                var sb = new StringBuilder(128);
                mciSendString($"status {alias} length", sb, 128, IntPtr.Zero);
                mciSendString($"close {alias}", null, 0, IntPtr.Zero);
                return int.TryParse(sb.ToString(), out var i) ? i : 0;
            }
            return 0;
        }

        /// <summary>
        /// Get the duration of a wav file in ms.
        /// This is completely thread-safe and may run on simultaneously on any thread.
        /// Warning: MediaDuration() and WaveDuration() results may be mismatched by 1ms due to rounding.
        /// </summary>
        /// <returns>ms duration or 0 upon error</returns>
        public static int WaveDuration(string wavFile)
        {
            return new WaveHeader(wavFile).AudioDuration();
        }

        private class WaveHeader
        {
            //http://soundfile.sapp.org/doc/WaveFormat/
            private const int MagicID = 0x46464952; //="RIFF"
            private const int WaveChunkHeaderID = 0x45564157; //=“WAVE”
            private const int FmtSubChunkHeaderID = 0x20746d66; //="fmt "
            private const int DataSubChunkHeaderID = 0x61746164; //="data " or  "atad" (0x64617461) big-endian form

            public readonly int Magic;             //="RIFF"
            public readonly int FileSize;          //Size of the overall file - 8 bytes, in bytes (32-bit integer). 
            public readonly int WaveChunkHeader;   //="wave". Type Header. For our purposes, it always equals “WAVE”.
            public readonly int FmtSubChunkHeader; //Format chunk marker == "fmt "
            public readonly int FmtSize;           //Length of 'fmt ' chunk
            public readonly short AudioFormat;     //Type of format (1 is PCM)
            public readonly short NumChannels;     //1=Mono, 2=Stereo, etc 
            public readonly int SampleRate;        //Common values are 44100 (CD), 48000 (DAT). Sample Rate = Number of Samples per second, or Hertz.
            public readonly int ByteRate;          //== SampleRate * NumChannels * BitsPerSample/8
            public readonly short BlockAlign;      //== NumChannels * BitsPerSample/8
            public readonly short BitsPerSample;   //8 bits = 8, 16 bits = 16, etc.
            public readonly int DataSubChunkHeader; //=“data” chunk header. Marks the beginning of the data section.
            public readonly int DataSize;           //Size of the following data.

            public int AudioDuration()
            {
                if (Magic != MagicID || WaveChunkHeader != WaveChunkHeaderID || FmtSubChunkHeader != FmtSubChunkHeaderID) return 0;
                return (int)(DataSize / (SampleRate * NumChannels * BitsPerSample / 8.0) * 1000 + 0.5);
            }

            public WaveHeader(string wavFile)
            {
                using (var fs = new FileStream(wavFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, FileOptions.SequentialScan))
                {
                    if (fs.Length < 44) return;  //sizeof(WaveHeader)
                    using (var br = new BinaryReader(fs))
                    {
                        Magic = br.ReadInt32();
                        FileSize = br.ReadInt32();
                        WaveChunkHeader = br.ReadInt32();
                        FmtSubChunkHeader = br.ReadInt32();
                        FmtSize = br.ReadInt32();
                        AudioFormat = br.ReadInt16();
                        NumChannels = br.ReadInt16();
                        SampleRate = br.ReadInt32();
                        ByteRate = br.ReadInt32();
                        BlockAlign = br.ReadInt16();
                        BitsPerSample = br.ReadInt16();
                        DataSubChunkHeader = br.ReadInt32();
                        DataSize = br.ReadInt32();
                    }
                }
            }
        }
    }
}
