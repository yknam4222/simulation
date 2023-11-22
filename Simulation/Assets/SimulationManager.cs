using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    public Toggle modelAToggle;
    public Toggle modelBToggle;
    public Button startButton;
    public Button pauseResumeButton;
    public Slider timeScaleSlider;
    public Text pauseResumeText;

    public bool simulationRunning = false;

    private SpeedControl speedControl;

    void Start()
    {
        startButton.onClick.AddListener(StartSimulation);
        pauseResumeButton.onClick.AddListener(TogglePauseResume);
        timeScaleSlider.onValueChanged.AddListener(ChangeTimeScale);
        speedControl = GameObject.Find("Slider").GetComponent<SpeedControl>();
        Time.timeScale = 0f;
    }

    void Update()
    {
        // 여기에 필요한 다른 업데이트 로직을 추가하세요.
    }

    void StartSimulation()
    {
        // 둘 다 선택되었거나 둘 다 선택되지 않았을 경우 실행하지 않음
        if ((modelAToggle.isOn && modelBToggle.isOn) || (!modelAToggle.isOn && !modelBToggle.isOn))
        {
            Debug.Log("Select one model before starting the simulation.");
            return;
        }

        // 여기에 시뮬레이션 시작 로직 추가
        Time.timeScale = 1f;
        simulationRunning = true;
        // 시뮬레이션 시작 후 버튼 상태 업데이트
        startButton.interactable = false;
        modelAToggle.interactable = false;
        modelBToggle.interactable = false;

        speedControl.sliderinteractable = true;
        pauseResumeButton.interactable = true;
    }

    void TogglePauseResume()
    {
        if (simulationRunning)
        {
            // 시뮬레이션 일시 중지
            Time.timeScale = 0f;
            pauseResumeText.text = "Resume";
        }
        else
        {
            // 시뮬레이션 재개
            if (speedControl.speedSlider.value == 0)
                Time.timeScale = 1f;
            else
                Time.timeScale = speedControl.speedSlider.value;

            pauseResumeText.text = "Pause";
        }

        // 시뮬레이션 상태 업데이트
        simulationRunning = !simulationRunning;
        speedControl.sliderinteractable = simulationRunning;
    }

    void ChangeTimeScale(float newScale)
    {
        if (simulationRunning)
        {
            // 시뮬레이션 중일 때만 Time.timeScale 조절
            Time.timeScale = newScale;
        }
    }
}
