using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Main._Scripts.ImageLoaderLogic
{
    [CreateAssetMenu(fileName = "ImageReferencesData", menuName = "Create new image reference data", order = 0)]
    public class ImageReferencesData : ScriptableObject
    {
        [field: SerializeField] public List<AssetReference> ImagesReference { get; private set; }
    }
}