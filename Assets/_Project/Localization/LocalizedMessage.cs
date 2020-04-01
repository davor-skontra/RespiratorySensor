using System;

namespace UnityEngine
{
    [Serializable]
    public class LocalizedMessage
    {
        [SerializeField, Multiline] private string text;
        [SerializeField] private Sprite image;
        [SerializeField] private AudioClip audio;

        public string Text => text;
        public Sprite Image => image;
        public AudioClip Audio => audio;
    }
}