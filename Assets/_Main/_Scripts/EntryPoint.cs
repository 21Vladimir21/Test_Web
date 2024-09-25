using _Main._Scripts.ImageLoaderLogic;
using _Main._Scripts.UI;
using UnityEngine;

namespace _Main._Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MainView mainView;
        [SerializeField] private ImageReferencesData referencesData;
        private ImagesLoader _imagesLoader;
        private void Awake()
        {
            _imagesLoader = new ImagesLoader(referencesData, mainView);
        }
    }
}