using UnityEngine;
using UnityEngine.SceneManagement;

namespace RAP.Main_Menu
{
    public class Menu : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }

        public void Play()
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
