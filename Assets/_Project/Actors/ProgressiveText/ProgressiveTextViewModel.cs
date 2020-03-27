using System;
using Actors.ProgressiveText;
using DG.Tweening;
using UnityEngine;

namespace ViewModels
{
    public class ProgressiveTextViewModel : IDisposable
    {
        private readonly ProgressiveTextModel _model;
        private readonly ProgressiveScreenSettings _settings;

        private bool _initialized;

        private Tweener _animation;
        private Color _textColor;
        private Color _initialTextColor;

        public event Action<string> TextEvent;
        public event Action<Color> TextColorEvent;
        public event Action<Sprite> ImageEvent;
        public event Action<bool> ImageVisibilityEvent;

        public ProgressiveTextViewModel(ProgressiveTextModel model, ProgressiveScreenSettings settings)
        {
            _model = model;
            _settings = settings;

            _model.ChangeScreenEvent += OnNextScreen;
        }

        private Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                TextColorEvent?.Invoke(_textColor);
            }
        }

        private void OnNextScreen(ProgressiveScreen screen)
        {
            if (_initialized)
            {
                _animation?.Kill();

                DOTween
                    .To(
                        () => TextColor,
                        x => TextColor = x,
                        Color.clear,
                        _settings.ChangeSpeed
                    )
                    .SetEase(_settings.Ease)
                    .OnComplete(() => SetTextAndImage(screen))
                    .SetLoops(1, LoopType.Yoyo);
            }
            else
            {
                _initialTextColor = TextColor;
            }
        }

        private void SetTextAndImage(ProgressiveScreen screen)
        {
            TextEvent?.Invoke(screen.Text);

            if (screen.Image != null)
            {
                ImageVisibilityEvent?.Invoke(true);
                ImageEvent?.Invoke(screen.Image);
            }
            else
            {
                ImageVisibilityEvent?.Invoke(false);
            }
        }

        public void Dispose()
        {
            _model.ChangeScreenEvent -= OnNextScreen;
        }
    }
}