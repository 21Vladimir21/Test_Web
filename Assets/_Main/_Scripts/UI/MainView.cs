using UnityEngine;
using UnityEngine.UI;

namespace _Main._Scripts.UI
{
    public class MainView : MonoBehaviour
    {
        [field:SerializeField] public Button LoadImageButton { get; private set; }
        [field:SerializeField] public RectTransform ImagesPanert { get; private set; }
        
    }
}