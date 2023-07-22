using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButtonScript : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
