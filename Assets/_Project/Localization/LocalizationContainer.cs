using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    [CreateAssetMenu(menuName = "Localization Container")]
    public class LocalizationContainer: ScriptableObject
    {
        [SerializeField] private LocalizedTexts[] textLocalizations;
        [SerializeField] private LocalizedAudios[] audioLocalization;

        public LocalizedTexts GetLocalizedTextsFor(SystemLanguage language) => textLocalizations
            .First(x => x.Language == language);
        
        public LocalizedAudios GetLocalizedAudiosFor(SystemLanguage language) => audioLocalization
            .First(x => x.Language == language);
    }
}