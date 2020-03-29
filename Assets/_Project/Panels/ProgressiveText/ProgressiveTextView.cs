using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Panels.ProgressiveText
{
    public class ProgressiveTextView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private UnityEngine.UI.Image image;
        [SerializeField] private Button button;

        [Inject] private ProgressiveTextViewModel _viewModel;

        private readonly Color _defaultMaterialColor = Color.white;
        
        private void Start()
        {
            _viewModel.TextEvent += SetText;
            _viewModel.TextAndImageColorEvent += SetTextAndImageColor;
            _viewModel.ImageEvent += SetImage;
            _viewModel.ImageVisibilityEvent += SetImageVisibility;
            _viewModel.ShouldBeVisibleEvent += SetPanelVisibility;

            image.material.color = _defaultMaterialColor;

            button.onClick.AddListener(_viewModel.RequestNextScreen);
            
            _viewModel.RequestNextScreen();
        }
        
        private void OnDestroy()
        {
            _viewModel.TextEvent -= SetText;
            _viewModel.TextAndImageColorEvent -= SetTextAndImageColor;
            _viewModel.ImageEvent -= SetImage;
            _viewModel.ImageVisibilityEvent -= SetImageVisibility;
            _viewModel.ShouldBeVisibleEvent -= SetPanelVisibility;

            image.material.color = _defaultMaterialColor;
            
            button.onClick.RemoveListener(_viewModel.RequestNextScreen);
        }

        private void SetText(string t) => text.text = t;

        private void SetTextAndImageColor(Color c)
        {
            text.color = c;
            image.material.color = c;
        }

        private void SetImage(Sprite s) => image.sprite = s;

        private void SetImageVisibility(bool v) => image.enabled = v;

        private void SetPanelVisibility(bool v) => gameObject.SetActive(v);

    }
}