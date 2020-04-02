using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(fileName = nameof(LocalizedMessageSequence), menuName = "Localized Message Sequence")]
    public class LocalizedMessageSequence : ScriptableObject
    {
        [SerializeField] private LocalizedMessage[] messages;
        
        public LocalizedMessage[] Messages => messages;
    }
}