using UnityEngine;

namespace UnityEngine
{
    [CreateAssetMenu(fileName = nameof(LocalizedMessageContainer), menuName = "Localized Message Container")]
    public class LocalizedMessageContainer : ScriptableObject
    {
        [SerializeField] private LocalizedMessage[] messages;
        
        public LocalizedMessage[] Messages => messages;
    }
}