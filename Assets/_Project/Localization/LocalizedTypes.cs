using System;

namespace UnityEngine
{
    public abstract class LocalizedType<T>
    {
        protected abstract T English { get; }
        protected abstract T Finnish { get; }

        public T Get(SystemLanguage language)
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
    }

    [Serializable]
    public class LocalizedString: LocalizedType<string>
    {
        [SerializeField] private string english;
        [SerializeField] private string finnish;
        protected override string English => english;
        protected override string Finnish => finnish;
    }
}