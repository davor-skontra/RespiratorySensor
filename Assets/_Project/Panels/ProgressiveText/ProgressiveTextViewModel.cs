using System;
using DG.Tweening;
using Localization;
using UnityEngine;

namespace Panels.ProgressiveText
{
    public class ProgressiveTextViewModel : PanelViewModel, IDisposable
    {
        private readonly ProgressiveTextModel _model;
        private readonly ProgressiveScreenSettings _settings;
        private readonly PanelVisibilityManager _visibilityManager;

        private bool _initialized;

        private Sequence _animation;
        private Color _textAndImageAndImageColor = Color.white;
        private Color _initialTextColor;

        public event Action<string> TextEvent;
        public event Action<Color> TextAndImageColorEvent;
        public event Action<Sprite> ImageEvent;
        public event Action<bool> ImageVisibilityEvent;

        public ProgressiveTextViewModel(ProgressiveTextModel model, ProgressiveScreenSettings settings, PanelVisibilityManager visibilityManager)
        {
            _model = model;
            _settings = settings;
            _visibilityManager = visibilityManager;

            _model.ChangeScreenEvent += OnNextScreen;
            _model.DoneWithProgressiveScreensEvent += ShowMeasurementPanel;
            
            _visibilityManager.RegisterPanel(this);

        }

        public override PanelKind PanelKind => PanelKind.ProgressiveText;
        public void RequestNextScreen() => _model.RequestNextScreen();

        private void ShowMeasurementPanel()
        {
            SetVisiblePanel(PanelKind.Measurement);
        }

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

        private void OnNextScreen(LocalizedMessage message)
        {
            if (_initialized)
            {
                _animation?.Kill();

                _animation = DOTween.Sequence()
                    .Append(AnimateColorTo(Color.clear))
                    .AppendCallback(() => SetTextAndImageInstant(message))
                    .Append(AnimateColorTo(_initialTextColor))
                    .Play();
            }
            else
            {
                SetTextAndImageInstant(message);
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

        private void SetTextAndImageInstant(LocalizedMessage message)
        {
            TextEvent?.Invoke(message.Text.Get);

            if (message.Sprite.Get != null)
            {
                ImageVisibilityEvent?.Invoke(true);
                ImageEvent?.Invoke(message.Sprite.Get);
            }
            else
            {
                ImageVisibilityEvent?.Invoke(false);
            }
        }

        public void Dispose()
        {
            _model.ChangeScreenEvent -= OnNextScreen;
            _model.DoneWithProgressiveScreensEvent -= ShowMeasurementPanel;
        }
    }
}