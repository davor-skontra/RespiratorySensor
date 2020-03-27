using System;
using Actors.ProgressiveText;
using UnityEngine;

namespace ViewModels
{
    public class ProgressiveTextViewModel: IDisposable
    {
        private readonly ProgressiveTextModel _model;

        private bool _initialized;
        public event Action<string> TextEvent;
        public event Action<Color> TextColorEvent;
        public event Action<bool> TextIsEnabledEvent;

        public ProgressiveTextViewModel(ProgressiveTextModel model)
        {
            _model = model;

            _model.ChangeScreenEvent += OnNextScreen;
        }

        private void OnNextScreen(ProgressiveScreen screen)
        {
            if (_initialized)
            {
                
            }
        }

        public void Dispose()
        {
            _model.ChangeScreenEvent -= OnNextScreen;
        }
    }
}