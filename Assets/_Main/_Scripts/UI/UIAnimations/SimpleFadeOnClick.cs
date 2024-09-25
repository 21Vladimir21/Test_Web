using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Main._Scripts.UI.UIAnimations
{
    [RequireComponent(typeof(CanvasGroup), typeof(Button))]
    public class SimpleFadeOnClick : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        [SerializeField] private Button button;

        [Space] [Range(0.1f, 300), SerializeField]
        private float cycleTime;


        private Coroutine _fadeRoutine;


        private void Awake()
        {
            button.onClick.AddListener(StartAnimation);
        }

        private void StartAnimation()
        {
            if (_fadeRoutine != null)
            {
                StopCoroutine(_fadeRoutine);
                _fadeRoutine = null;
            }

            _fadeRoutine = StartCoroutine(FadeAnimation());
        }

        private IEnumerator FadeAnimation()
        {
            while (true)
            {
                var newValue = 1 - group.alpha;
                float elapsedTime = 0;
                while (true)
                {
                    elapsedTime += Time.deltaTime;
                    var progress = elapsedTime / cycleTime;
                    group.alpha = Mathf.Lerp(group.alpha, newValue, progress);
                    if (progress >= 1)
                        break;
                    yield return null;
                }
            }
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (group == null) group = GetComponent<CanvasGroup>();
            if (button == null) button = GetComponent<Button>();
        }
#endif
    }
}