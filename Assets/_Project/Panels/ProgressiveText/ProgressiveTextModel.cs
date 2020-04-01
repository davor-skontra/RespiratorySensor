using System;
using Localization;
using Panels.ProgressiveText.Image;

namespace Panels.ProgressiveText
{
    public class ProgressiveTextModel
    {
        private int _currentScreen = 0;

        public event Action<InformationContainer> ChangeScreenEvent;
        public event Action DoneWithProgressiveScreensEvent;

        public ProgressiveTextModel(
            LocalizedTexts localizedTexts,
            LocalizedAudios localizedAudios,
            ImageContainer images
        )
        {
            Screens = new[]
            {
                InformationContainer.From(
                    localizedTexts.PressButtonToStart
                ),
                InformationContainer.From(
                    localizedTexts.WhenReadyPlaceAndWait,
                    image: images.Instruction
                )
            };
        }

        private InformationContainer[] Screens { get; }

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