using Actors.ProgressiveText;
using ResourceContainers;
using UnityEngine;
using ViewModels;
using Zenject;

namespace Di
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private ProgressiveScreenSettings settings;
        
        public override void InstallBindings()
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