using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    [SerializeField] KeyCode m_triggerButton;
    [SerializeField] TMP_Text SpeedText;
    [SerializeField] Slider m_SpeedSlider;
    [SerializeField] string m_SwitchSceneName;

    private void Start()
    {
        LoadData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_triggerButton))
        {
            SceneManager.LoadScene(m_SwitchSceneName);
        }
    }

    public void UpdateSpeed(float sliderValue)
    {
        SpeedText.text = $"X{sliderValue:0.00}";
        InstanceData.Instance.Data.SpeedMultiplier = sliderValue;
    }

    public void ScreenModeChange(bool isFullScreen)
    {
        InstanceData.Instance.Data.IsFullScreen = isFullScreen;
        Screen.fullScreen = InstanceData.Instance.Data.IsFullScreen;
    }

    private void LoadData()
    {
        m_SpeedSlider.value = InstanceData.Instance.Data.SpeedMultiplier;
    }
}
