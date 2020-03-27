using UnityEngine;

namespace Actors.ProgressiveText
{
    public struct ProgressiveScreen
    {
        public static ProgressiveScreen From(string text, AudioClip audio = null, Sprite image = null)
        {
            return new ProgressiveScreen(text, audio, image);
        }

        private ProgressiveScreen(string text, AudioClip audio, Sprite image)
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