using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    [SerializeField] KeyCode m_triggerButton;
    [SerializeField] TMP_Text m_Text;
    [SerializeField] SnakeScript m_SnakeScript;
    [SerializeField] Slider m_SpeedSlider;

    public string SwitchSceneName;

    private void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (objs.Length > 1)
        {
            Destroy(objs[0]);
        }

        DontDestroyOnLoad(gameObject);
        m_SpeedSlider.value = m_SnakeScript.SpeedMultiplier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_triggerButton))
        {
            SceneManager.LoadScene(SwitchSceneName);
        }
    }


    public void UpdateSpeed(float sliderValue)
    {
        m_Text.text = $"X{sliderValue:0.00}";
        m_SnakeScript.SpeedMultiplier = sliderValue;
    }
}
