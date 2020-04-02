using System;
using Localization;
using UnityEngine;

namespace Panels.ProgressiveText
{
    public class ProgressiveTextModel
    {
        private int _currentScreen = 0;

        public event Action<LocalizedMessage> ChangeScreenEvent;
        public event Action DoneWithProgressiveScreensEvent;

        public ProgressiveTextModel(
            LocalizedMessageSequence messageSequence
        )
        {
            Screens = messageSequence.Messages;
        }

        private LocalizedMessage[] Screens { get; }

        public void RequestNextScreen()
        {
            if (_currentScreen < Screens.Length)
            {
                ChangeScreenEvent?.Invoke(
                    Screens[_currentScreen++]
                );
            }
            else
            {
                DoneWithProgressiveScreensEvent?.Invoke();
            }
        }
    }
}