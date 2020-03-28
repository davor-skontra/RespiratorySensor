using UnityEngine;

namespace Panels.ProgressiveText.Image
{
    [CreateAssetMenu(fileName = nameof(ImageContainer), menuName = "Image Container")]
    public class ImageContainer: ScriptableObject
    {
        [SerializeField] private Sprite instructionImage;

        public Sprite Instruction => instructionImage;
    }
}