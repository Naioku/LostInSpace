using System;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float waitTimeBeforeLoadingLevel = 2f;
        private Coroutine _loadNextLevelCoroutine;

        private void Start()
        {
            FindObjectOfType<Messages>().FadeInOutMessage(SceneManager.GetActiveScene().name);
        }

        public void RestartLevel()
        {
            StartCoroutine(RestartLevelCoroutine());
        }
        
        public void LoadNextLevel()
        {
            if (_loadNextLevelCoroutine != null) return;
            _loadNextLevelCoroutine = StartCoroutine(LoadNextLevelCoroutine());
        }

        private IEnumerator RestartLevelCoroutine()
        {
            yield return new WaitForSecondsRealtime(waitTimeBeforeLoadingLevel);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private IEnumerator LoadNextLevelCoroutine()
        {
            yield return new WaitForSecondsRealtime(waitTimeBeforeLoadingLevel);

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
