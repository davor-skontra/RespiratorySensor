using System;
using Localization;
using ResourceContainers;
using UnityEngine;

namespace Actors.ProgressiveText
{
    public class ProgressiveTextModel
    {
        private int _currentScreen = 0;

        public event Action<Screen> ChangeScreenEvent;
        
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
            
        }
    }
}