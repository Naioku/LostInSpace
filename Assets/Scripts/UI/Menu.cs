using Movement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void OnResume()
        {
            Resume();
        }

        public void OnTitleScreen()
        {
            Resume();
            SceneManager.LoadScene(0);
        }

        public void OnPlay()
        {
            SceneManager.LoadScene(1);
        }

        public void OnQuit()
        {
            if (Application.isEditor)
            {
                UnityEngine.Debug.Log("Cannot quit the application (Application is editor).");
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void OnPause()
        {
            print("OnPause");
            if (GetComponent<Canvas>().enabled.Equals(true))
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        private void Pause()
        {
            Time.timeScale = 0;
            FindObjectOfType<PlayerMover>().enabled = false;
            FindObjectOfType<LightMover>().enabled = false;
            GetComponent<Canvas>().enabled = true;
        }

        private void Resume()
        {
            Time.timeScale = 1;
            FindObjectOfType<PlayerMover>().enabled = true;
            FindObjectOfType<LightMover>().enabled = true;
            GetComponent<Canvas>().enabled = false;
        }
    }
}
