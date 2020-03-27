using Localization;
using UnityEngine;
using Zenject;

namespace Di
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LocalizationContainer localizationContainer;

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
        }
    }
}