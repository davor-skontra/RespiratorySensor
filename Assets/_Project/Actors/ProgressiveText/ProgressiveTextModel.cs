using System;
using Localization;
using ResourceContainers;

namespace Actors.ProgressiveText
{
    public class ProgressiveTextModel
    {
        private int _currentScreen = 0;

        public event Action<ProgressiveScreen> ChangeScreenEvent;
        public event Action DoneWithProgressiveScreensEvent;

        public ProgressiveTextModel(
            LocalizedTexts localizedTexts,
            LocalizedAudios localizedAudios,
            ImageContainer images
        )
        {
            Screens = new[]
            {
                ProgressiveScreen.From(
                    localizedTexts.PressButtonToStart
                ),
                ProgressiveScreen.From(
                    localizedTexts.WhenReadyPlaceAndWait
                )
            };
        }

        private ProgressiveScreen[] Screens { get; }

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