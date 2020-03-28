using Localization;
using ResourceContainers;
using UnityEngine;
using Zenject;

namespace Di
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LocalizationContainer localizationContainer;
        [SerializeField] private ImageContainer imageContainer;

        public override void InstallBindings()
        {
            Container
                .BindInstance(
                    localizationContainer.GetLocalizedTextsFor(Application.systemLanguage)
                )
                .AsSingle();
            
            Container
                .BindInstance(
                    localizationContainer.GetLocalizedAudiosFor(Application.systemLanguage)
                )
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ImageContainer>()
                .FromInstance(imageContainer)
                .AsSingle();
        }
    }
}