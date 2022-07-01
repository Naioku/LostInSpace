using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void OnTitleScreen()
        {
            SceneManager.LoadScene(9);
        }
        
        public void OnPlay()
        {
            SceneManager.LoadScene(0);
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
    }
}
