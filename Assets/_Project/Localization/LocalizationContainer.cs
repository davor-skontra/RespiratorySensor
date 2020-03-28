using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    [CreateAssetMenu(menuName = "Localization Container")]
    public class LocalizationContainer: ScriptableObject
    {
        [SerializeField] private LocalizedTexts[] textLocalizations;
        [SerializeField] private LocalizedAudios[] audioLocalizations;

        public LocalizedTexts GetLocalizedTextsFor(SystemLanguage language) => textLocalizations
            .FirstOrDefault(x => x.Language == language) ?? textLocalizations.First();

        public LocalizedAudios GetLocalizedAudiosFor(SystemLanguage language) => audioLocalizations
            ?.FirstOrDefault(x => x.Language == language);
    }
}