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
        // ���⿡ �ʿ��� �ٸ� ������Ʈ ������ �߰��ϼ���.
    }

    void StartSimulation()
    {
        // �� �� ���õǾ��ų� �� �� ���õ��� �ʾ��� ��� �������� ����
        if ((modelAToggle.isOn && modelBToggle.isOn) || (!modelAToggle.isOn && !modelBToggle.isOn))
        {
            Debug.Log("Select one model before starting the simulation.");
            return;
        }

        // ���⿡ �ùķ��̼� ���� ���� �߰�
        Time.timeScale = 1f;
        simulationRunning = true;
        // �ùķ��̼� ���� �� ��ư ���� ������Ʈ
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
            // �ùķ��̼� �Ͻ� ����
            Time.timeScale = 0f;
            pauseResumeText.text = "Resume";
        }
        else
        {
            // �ùķ��̼� �簳
            if (speedControl.speedSlider.value == 0)
                Time.timeScale = 1f;
            else
                Time.timeScale = speedControl.speedSlider.value;

            pauseResumeText.text = "Pause";
        }

        // �ùķ��̼� ���� ������Ʈ
        simulationRunning = !simulationRunning;
        speedControl.sliderinteractable = simulationRunning;
    }

    void ChangeTimeScale(float newScale)
    {
        if (simulationRunning)
        {
            // �ùķ��̼� ���� ���� Time.timeScale ����
            Time.timeScale = newScale;
        }
    }
}
