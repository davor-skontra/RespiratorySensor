using System;
using UnityEngine;

namespace Localization
{
    public abstract class LocalizedType<T>
    {
        protected abstract T English { get; }
        protected abstract T Finnish { get; }

        public T GetSpecific(SystemLanguage language)
        {
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (language)
            {
                case (SystemLanguage.Finnish):
                    return Finnish;
                default:
                    return English;
            }
        }

        public T Get => GetSpecific(Application.systemLanguage);
    }
    
    [Serializable]
    public class LocalizedMultilineString: LocalizedType<string>
    {
        [SerializeField, Multiline] private string english;
        [SerializeField, Multiline] private string finnish;
        protected override string English => english;
        protected override string Finnish => finnish;
    }

    [Serializable]
    public class LocalizedString: LocalizedType<string>
    {
        [SerializeField] private string english;
        [SerializeField] private string finnish;
        protected override string English => english;
        protected override string Finnish => finnish;
    }
    
    [Serializable]
    public class LocalizedAudioClip: LocalizedType<AudioClip>
    {
        [SerializeField] private AudioClip english;
        [SerializeField] private AudioClip finnish;
        protected override AudioClip English => english;
        protected override AudioClip Finnish => finnish;
    }
    
    [Serializable]
    public class LocalizedSprite: LocalizedType<Sprite>
    {
        [SerializeField] private Sprite english;
        [SerializeField] private Sprite finnish;
        protected override Sprite English => english;
        protected override Sprite Finnish => finnish;
    }
}