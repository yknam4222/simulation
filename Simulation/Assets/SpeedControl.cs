using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Slider speedSlider; // UI Slider를 연결할 변수
    public Text timeScaleText; // UI Text를 연결할 변수

    void Start()
    {
        // Slider에 이벤트 리스너 추가
        speedSlider.onValueChanged.AddListener(ChangeSpeed);

        // 초기 Text 값을 설정
        UpdateTimeScaleText();
    }

    void Update()
    {
        // 실제로는 이 부분에 게임 로직이 들어갑니다.
        // Time.deltaTime을 사용하는 모든 부분이 속도 조절의 영향을 받습니다.
    }

    // Slider 값이 변경될 때 호출되는 메서드
    public void ChangeSpeed(float newSpeed)
    {
        // Slider 값으로 Time.timeScale을 조절 (범위: 1 ~ 60)
        Time.timeScale = Mathf.Clamp(newSpeed, 1f, 60f);

        // 변경된 Time.timeScale 값을 Text에 반영
        UpdateTimeScaleText();
    }

    // Text UI를 업데이트하는 메서드
    void UpdateTimeScaleText()
    {
        timeScaleText.text = Time.timeScale.ToString("F1");
    }
}
