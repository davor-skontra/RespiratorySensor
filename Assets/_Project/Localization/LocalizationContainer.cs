using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(menuName = "Localization Container")]
    public class LocalizationContainer: ScriptableObject
    {
        [SerializeField] private Texts[] textLocalizations;
        [SerializeField] private Audios[] audioLocalization;
        
        
    }
}