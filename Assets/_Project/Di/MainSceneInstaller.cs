using Measurement;
using Panels;
using Panels.MeasurementPanel;
using Panels.ProgressiveText;
using UnityEngine;
using Zenject;

namespace Di
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private ProgressiveScreenSettings progressiveSettings;
        
        public override void InstallBindings()
        {
            BindMeasurementPanel();
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
                .FromInstance(progressiveSettings)
                .AsSingle();
        }

        private void BindMeasurementPanel()
        {
            Container
                .BindInterfacesAndSelfTo<PlaceholderMeasurementService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<MeasurementPanelModel>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GravityDirectionProvider>()
                .AsSingle();
        }
    }
}