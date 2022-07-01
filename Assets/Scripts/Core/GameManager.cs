using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float waitTimeBeforeLoadingLevel = 2f;

        public void RestartLevel()
        {
            StartCoroutine(RestartLevelCoroutine());
        }

        private IEnumerator RestartLevelCoroutine()
        {
            yield return new WaitForSecondsRealtime(waitTimeBeforeLoadingLevel);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
