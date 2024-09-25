using System.Collections.Generic;
using _Main._Scripts.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace _Main._Scripts.ImageLoaderLogic
{
    public class ImagesLoader
    {
        private readonly ImageReferencesData _data;
        private readonly MainView _mainView;
        private List<Image> _createdImages = new();

        public ImagesLoader(ImageReferencesData data, MainView mainView)
        {
            _data = data;
            _mainView = mainView;
            _mainView.LoadImageButton.onClick.AddListener(LoadImages);
        }

        private void LoadImages()
        {
            ClearCreatedImages();
            foreach (var reference in _data.ImagesReference)
            {
                var handle = Addressables.LoadAssetAsync<Sprite>(reference);
                handle.Completed += operationHandle =>
                {
                    if (operationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        var image = CreateImage();
                        _createdImages.Add(image);
                        image.sprite = operationHandle.Result;
                    }
                };
            }
        }

        private void ClearCreatedImages()
        {
            foreach (var image in _createdImages) Object.Destroy(image.gameObject);
            _createdImages.Clear();
        }

        private Image CreateImage()
        {
            var imageObject = new GameObject("NewImage");
            imageObject.transform.SetParent(_mainView.ImagesPanert, false);
            var image = imageObject.AddComponent<Image>();
            return image;
        }
    }
}