using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using TriviaClientApp.Properties;

namespace TriviaClientApp
{
    public partial class SoundManager
    {
        private const string SOUNDS_FOLDER = "sounds\\";

        private const string CORRECT_ANSWER_SOUND = "correctAnswerSound.wav";
        private const string WRONG_ANSWER_SOUND = "wrongAnswerSound.wav";
        private const string COUNTDOWN_TIMER_SOUND = "countdownTimerSound.wav";
        private const string MENU_THEME_SOUND = "menuThemeSound.wav";
        private const string GAME_THEME_SOUND = "gameThemeSound.wav";

        private SoundPlayer buttonClickSound;
        private SoundPlayer correctAnswerSound;
        private SoundPlayer wrongAnswerSound;
        private SoundPlayer countdownTimerSound;
        private SoundPlayer menuThemeSound;
        private SoundPlayer gameThemeSound;


        private static SoundManager? instance = null;

        public SoundManager()
        {
            instance = this;
            buttonClickSound = new SoundPlayer(Resources.buttonClickSound);
            correctAnswerSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + CORRECT_ANSWER_SOUND);
            wrongAnswerSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + WRONG_ANSWER_SOUND);
            countdownTimerSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + COUNTDOWN_TIMER_SOUND);
            menuThemeSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + MENU_THEME_SOUND);
            gameThemeSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + GAME_THEME_SOUND);
        }

        /// <summary>
        /// get the sound manager
        /// </summary>
        /// <returns>the sound manager</returns>
        public static SoundManager GetSoundManager()
        {
            return instance;
        }

        public static void PlaySound(SoundPlayer sound)
        {
            sound.PlaySync();
            Thread.Sleep(sound.SoundLocation.Length);
        }

        public void PlayButtonClickSound()
        {
            Thread thread = new Thread(() => PlaySound(buttonClickSound));
            thread.Start();
        }

        public void PlayCorrectAnswerSound()
        {
            Thread thread = new Thread(() => PlaySound(correctAnswerSound));
            thread.Start();
        }

        public void PlayWrongAnswerSound()
        {
            Thread thread = new Thread(() => wrongAnswerSound.Play());
            thread.Start();
        }

        public void PlayCountdownTimerSound()
        {
            Thread thread = new Thread(() => PlaySound(countdownTimerSound));
            thread.Start();
        }

        public void StartMenuThemeSound()
        {
            menuThemeSound.PlayLooping();
        }

        public void StopMenuThemeSound()
        {
            menuThemeSound.Stop();
        }

        public void StartGameThemeSound()
        {
            gameThemeSound.PlayLooping();
        }

        public void StopGameThemeSound()
        {
            gameThemeSound.Stop();
        }

    }
}
