using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Speech
{
    class TextToSpeech
    {
        public SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public void createSynthesizer()
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Rate = -5;
        }
        public String SpeakString;
        public void speakText(String str)
        {
            createSynthesizer();
            SpeakString = str;
            if (!str.Equals(null))
            {
                speechSynthesizer.SpeakAsync(SpeakString);
            }

        }
        public void pauseSpeech()
        {
            speechSynthesizer.Pause();
        }
        public void resumeSpeech()
        {
            speechSynthesizer.Resume();
        }
        public void stopSpeech()
        {
            speechSynthesizer.Dispose();
            createSynthesizer();
            SpeakString = null;
        }

        public void changeRate(int rate)
        {
            speechSynthesizer.Rate = rate;
        }

    }
}
