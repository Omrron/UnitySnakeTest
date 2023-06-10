using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void SwitchScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }    

}
