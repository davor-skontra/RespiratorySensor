using System;
using UnityEngine;

namespace Localization
{
    [Serializable]
    public class LocalizedMessage
    {
        [SerializeField] private LocalizedMultilineString text;
        [SerializeField] private LocalizedAudioClip audio;
        [SerializeField] private LocalizedSprite sprite;

        public LocalizedMultilineString Text => text;
        public LocalizedSprite Sprite => sprite;
        public LocalizedAudioClip Audio => audio;
    }
}