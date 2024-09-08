using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIElementController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource backgroundAudio;

    public Slider sizeSlider;
    public RectTransform objectToResize;

    public Toggle soundToggle;

    public Toggle lightToggle;
    public GameObject darkOverlay;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeUpText;
    private float elapsedTime = 0f;
    private bool timerRunning = true;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        sizeSlider.onValueChanged.AddListener(ChangeSize);

        soundToggle.onValueChanged.AddListener(ToggleSound);

        lightToggle.onValueChanged.AddListener(ToggleLight);
    }

    void ChangeVolume(float value)
    {
        backgroundAudio.volume = value;
    }

    void ChangeSize(float value)
    {
        objectToResize.sizeDelta = new Vector2(value * 100, value * 100);
    }

    void ToggleSound(bool isOn)
    {
        backgroundAudio.mute = !isOn;
    }

    void ToggleLight(bool isOn)
    {
        darkOverlay.SetActive(!isOn);
    }

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            int hours = (int)(elapsedTime / 3600);
            int minutes = (int)((elapsedTime % 3600) / 60);
            int seconds = (int)(elapsedTime % 60);
            timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";

            if (elapsedTime >= 120)
            {
                timerRunning = false;
                ShowTimeUp();
            }
        }
    }

    void ShowTimeUp()
    {
        timeUpText.text = "Time Up!";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
