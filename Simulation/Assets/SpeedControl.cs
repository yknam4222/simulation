using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Slider speedSlider; // UI Slider�� ������ ����
    public Text timeScaleText; // UI Text�� ������ ����
    private SimulationManager simulationManager;

    public bool sliderinteractable;
    void Start()
    {
        // Slider�� �̺�Ʈ ������ �߰�
        speedSlider.onValueChanged.AddListener(ChangeSpeed);
        // �ʱ� Text ���� ����
        UpdateTimeScaleText();
        sliderinteractable = false;
    }

    void Update()
    {
        speedSlider.interactable = sliderinteractable;
    }

    // Slider ���� ����� �� ȣ��Ǵ� �޼���
    public void ChangeSpeed(float newSpeed)
    {
        // Slider ������ Time.timeScale�� ���� (����: 1 ~ 60)
        Time.timeScale = Mathf.Clamp(newSpeed, 1f, 60f);

        // ����� Time.timeScale ���� Text�� �ݿ�
        UpdateTimeScaleText();
    }

    // Text UI�� ������Ʈ�ϴ� �޼���
    void UpdateTimeScaleText()
    {
        timeScaleText.text = Time.timeScale.ToString("F1");
    }
}
