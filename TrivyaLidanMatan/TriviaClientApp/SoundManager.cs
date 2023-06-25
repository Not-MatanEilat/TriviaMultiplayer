using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using TriviaClientApp.Properties;

namespace TriviaClientApp
{
    public class SoundManager
    {
        public readonly SoundPlayer buttonClickSound;
        public readonly SoundPlayer correctAnswerSound;
        public readonly SoundPlayer wrongAnswerSound;
        public readonly SoundPlayer countdownTimerSound;
        public readonly SoundPlayerBg menuThemeSound;
        public readonly SoundPlayerBg gameThemeSound;

        private static SoundManager? instance = null;

        public SoundManager()
        {
            instance = this;
            buttonClickSound = new SoundPlayer(Resources.buttonClickSound);
            buttonClickSound.Tag = "buttonClickSound";
            correctAnswerSound = new SoundPlayer(Resources.correctAnswerSound);
            correctAnswerSound.Tag = "correctAnswerSound";
            wrongAnswerSound = new SoundPlayer(Resources.wrongAnswerSound);
            wrongAnswerSound.Tag = "wrongAnswerSound";
            countdownTimerSound = new SoundPlayer(Resources.countdownTimerSound);
            countdownTimerSound.Tag = "countdownTimerSound";
            menuThemeSound = new SoundPlayerBg(Resources.menuThemeSound);
            menuThemeSound.Tag = "menuThemeSound";
            gameThemeSound = new SoundPlayerBg(Resources.gameThemeSound);
            gameThemeSound.Tag = "gameThemeSound";
        }

        /// <summary>
        /// get the sound manager
        /// </summary>
        /// <returns>the sound manager</returns>
        public static SoundManager GetSoundManager()
        {
            return instance;
        }

        /// <summary>
        /// play the button click sound
        /// </summary>
        public void PlayButtonClickSound()
        {
            buttonClickSound.Play();
        }

        /// <summary>
        /// play the correct answer sound
        /// </summary>
        public void PlayCorrectAnswerSound()
        {
            correctAnswerSound.Play();
        }

        /// <summary>
        /// play the wrong answer sound
        /// </summary>
        public void PlayWrongAnswerSound()
        {
            wrongAnswerSound.Play();
        }

        /// <summary>
        /// play the countdown timer sound
        /// </summary>
        public void PlayCountdownTimerSound()
        {
            countdownTimerSound.Play();
        }

        /// <summary>
        /// play the menu theme sound
        /// </summary>
        public void StartMenuThemeSound()
        {
            menuThemeSound.PlayLooping();
        }

        /// <summary>
        /// stop the menu theme sound
        /// </summary>
        public void StopMenuThemeSound()
        {
            menuThemeSound.Stop();
        }

        /// <summary>
        /// play the game theme sound
        /// </summary>
        public void StartGameThemeSound()
        {
            gameThemeSound.PlayLooping();
        }

        /// <summary>
        /// stop the game theme sound
        /// </summary>
        public void StopGameThemeSound()
        {
            gameThemeSound.Stop();
        }

    }

    public class SoundPlayerBg : SoundPlayer
    {
        private readonly AudioPlayer audioPlayer;

        public SoundPlayerBg()
        {
            audioPlayer = new AudioPlayer(MainForm.GetMainForm());
        }

        public SoundPlayerBg(Stream stream) : base(stream)
        {
            audioPlayer = new AudioPlayer(MainForm.GetMainForm());
            audioPlayer.Open(stream);
        }

        public SoundPlayerBg(string soundLocation) : base(soundLocation)
        {
            audioPlayer = new AudioPlayer(MainForm.GetMainForm());
            audioPlayer.Open(soundLocation);
        }

        /// <summary>
        /// Play the sound in the background
        /// </summary>
        public new void Play()
        {
            audioPlayer.Play(false);
            new Thread(() =>
            {
                Debug.WriteLine("Playing sound: " + Tag);
                Thread.Sleep(audioPlayer.AudioLength());
                audioPlayer.Stop();
                Debug.WriteLine("Stop Playing sound: " + Tag);
            }).Start();
        }

        /// <summary>
        /// Play the sound in the background
        /// </summary>
        public new void PlayLooping()
        {
            audioPlayer.Play(true);
        }

        /// <summary>
        /// Stop the sound
        /// </summary>
        public new void Stop()
        {
            // To stop the SoundPlayer wave file
            audioPlayer.Stop();
            Debug.WriteLine("Stopped sound!");
        }
    }

}
