using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(menuName = "Localized Text Container")]
    public class LocalizedTexts: LocalizationKind
    {
        [SerializeField, Multiline] private string pressButtonToStart;
        [SerializeField, Multiline] private string whenReadyPlaceAndWait;
        [SerializeField, Multiline] private string measurementWillStartInSeconds;
        
        public string PressButtonToStart => pressButtonToStart;
        public string WhenReadyPlaceAndWait => whenReadyPlaceAndWait;
        public string MeasurementWillStartInSeconds => measurementWillStartInSeconds;
    }
}
