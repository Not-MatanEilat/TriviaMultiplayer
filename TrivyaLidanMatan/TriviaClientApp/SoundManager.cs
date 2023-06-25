using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TriviaClientApp
{
    public partial class SoundManager
    {
        private const string SOUNDS_FOLDER = "sounds\\";

        private const string BUTTON_CLICK_SOUND = "buttonClickSound.wav"; 
        private const string CORRECT_ANSWER_SOUND = "correctAnswerSound.wav";
        private const string WRONG_ANSWER_SOUND = "wrongAnswerSound.wav";
        private const string COUNTDOWN_TIMER_SOUND = "countdownTimerSound.wav";

        private SoundPlayer buttonClickSound;
        private SoundPlayer correctAnswerSound;
        private SoundPlayer wrongAnswerSound;
        private SoundPlayer countdownTimerSound;


        private static SoundManager? instance = null;

        public SoundManager()
        {
            instance = this;
            buttonClickSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + BUTTON_CLICK_SOUND);
            correctAnswerSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + CORRECT_ANSWER_SOUND);
            wrongAnswerSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + WRONG_ANSWER_SOUND);
            countdownTimerSound = new SoundPlayer(Application.StartupPath + "\\" + SOUNDS_FOLDER + COUNTDOWN_TIMER_SOUND);
        }

        /// <summary>
        /// get the sound manager
        /// </summary>
        /// <returns>the sound manager</returns>
        public static SoundManager GetSoundManager()
        {
            return instance;
        }

        public void PlayButtonClickSound()
        {
            buttonClickSound.Play();
        }

        public void PlayCorrectAnswerSound()
        {
            correctAnswerSound.Play();
        }

        public void PlayWrongAnswerSound()
        {
            wrongAnswerSound.Play();
        }

        public void PlayCountdownTimerSound()
        {
            countdownTimerSound.Play();
        }

    }
}
