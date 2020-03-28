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

        private Sequence _animation;
        private Color _textAndImageAndImageColor = Color.white;
        private Color _initialTextColor;

        public event Action<string> TextEvent;
        public event Action<Color> TextAndImageColorEvent;
        public event Action<Sprite> ImageEvent;
        public event Action<bool> ImageVisibilityEvent;

        public ProgressiveTextViewModel(ProgressiveTextModel model, ProgressiveScreenSettings settings)
        {
            _model = model;
            _settings = settings;

            _model.ChangeScreenEvent += OnNextScreen;
        }

        public void RequestNextScreen() => _model.RequestNextScreen();

        private Color TextAndImageColor
        {
            get => _textAndImageAndImageColor;
            set
            {
                _textAndImageAndImageColor = value;
                Debug.Log(value);
                TextAndImageColorEvent?.Invoke(_textAndImageAndImageColor);
            }
        }

        private void OnNextScreen(ProgressiveScreen screen)
        {
            if (_initialized)
            {
                _animation?.Kill();

                _animation = DOTween.Sequence()
                    .Append(AnimateColorTo(Color.clear))
                    .AppendCallback(() => SetTextAndImageInstant(screen))
                    .Append(AnimateColorTo(_initialTextColor))
                    .Play();
            }
            else
            {
                SetTextAndImageInstant(screen);
                _initialTextColor = TextAndImageColor;
                _initialized = true;
            }

            Tweener AnimateColorTo(Color color) =>
                DOTween.To(
                        () => TextAndImageColor,
                        x => TextAndImageColor = x,
                        color,
                        _settings.ChangeSpeed
                    )
                    .SetEase(_settings.Ease);
        }

        private void SetTextAndImageInstant(ProgressiveScreen screen)
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