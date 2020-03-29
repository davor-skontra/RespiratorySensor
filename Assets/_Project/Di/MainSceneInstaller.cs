using Panels.PanelManagement;
using Panels.ProgressiveText;
using UnityEngine;
using Zenject;

namespace Di
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private ProgressiveScreenSettings settings;
        
        public override void InstallBindings()
        {
            BindVisibilityManager();
            BindProgressiveText();
        }

        private void BindVisibilityManager()
        {
            Container
                .BindInterfacesAndSelfTo<PanelVisibilityManager>()
                .AsSingle();
        }

        private void BindProgressiveText()
        {
            Container
                .BindInterfacesAndSelfTo<ProgressiveTextModel>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProgressiveTextViewModel>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProgressiveScreenSettings>()
                .FromInstance(settings)
                .AsSingle();
        }
    }
}