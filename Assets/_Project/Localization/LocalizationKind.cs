using UnityEngine;

namespace Localization
{
    public abstract class LocalizationKind: ScriptableObject
    {
        [SerializeField] private SystemLanguage language;
        
        public SystemLanguage Language => language;
    }
}