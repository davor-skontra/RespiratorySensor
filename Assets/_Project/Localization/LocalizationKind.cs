using UnityEngine;

namespace Localization
{
    public abstract class LocalizationKind: ScriptableObject
    {
        [SerializeField] private Language language;
    }
}