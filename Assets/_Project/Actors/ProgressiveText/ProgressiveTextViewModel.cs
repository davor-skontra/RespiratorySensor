using System;
using UnityEngine;

namespace ViewModels
{
    public class ProgressiveTextViewModel
    {
        public event Action<string> TextEvent;
        public event Action<Color> TextColorEvent;
        public event Action<bool> TextIsEnabledEvent;
    }
}