using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Defeat : MonoBehaviour
{
    public void mainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void tryAgainButton()
    {
        SceneManager.LoadScene("Game");
    }
}
