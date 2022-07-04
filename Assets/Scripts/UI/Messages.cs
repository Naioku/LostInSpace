using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Messages : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI displayedTextField;
        [SerializeField] private float fadeInTime = 1.2f;
        [SerializeField] private float fadeOutTime = 1.2f;
        [SerializeField] private float waitTimeBetweenFades = 1f;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0f;
        }

        public void FadeInOutMessage(string message)
        {
            displayedTextField.text = message;
            StartCoroutine(FadeInOut());
        }
        
        public void FadeInMessage(string message)
        {
            displayedTextField.text = message;
            displayedTextField.autoSizeTextContainer = true;
            StartCoroutine(FadeIn(fadeInTime));
        }

        private IEnumerator FadeInOut()
        {
            yield return FadeIn(fadeInTime);
            yield return new WaitForSecondsRealtime(waitTimeBetweenFades);
            yield return FadeOut(fadeOutTime);
        }

        private IEnumerator FadeIn(float time)
        {
            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime / time;
                yield return new WaitForEndOfFrame();
            }
        }
        
        private IEnumerator FadeOut(float time)
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime / time;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
