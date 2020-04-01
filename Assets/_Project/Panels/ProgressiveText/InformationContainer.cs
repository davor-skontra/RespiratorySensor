using UnityEngine;

namespace Panels.ProgressiveText
{
    public struct InformationContainer
    {
        public static InformationContainer From(string text, AudioClip audio = null, Sprite image = null)
        {
            return new InformationContainer(text, audio, image);
        }

        private InformationContainer(string text, AudioClip audio, Sprite image)
        {
            Text = text;
            Audio = audio;
            Image = image;
        }
        
        public string Text { get; }
        public AudioClip Audio { get; }
        public Sprite Image { get; }
    }
}