using DG.Tweening;
using UnityEngine;

namespace Panels.ProgressiveText
{
    [CreateAssetMenu(fileName = nameof(ProgressiveScreenSettings), menuName = "Progressive Screen Settings")]
    public class ProgressiveScreenSettings : ScriptableObject
    {
        [SerializeField] private float changeSpeed;
        [SerializeField] private Ease ease;

        public float ChangeSpeed => changeSpeed;
        public Ease Ease => ease;
    }
}