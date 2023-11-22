using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    private Text orderText; // UI Text 객체를 저장할 변수
    private Text TotalOrderText; // TotalOrderText
    [HideInInspector] public Text waitingTimeText;
    private Text simulationTimeText; // 시뮬레이션 시간

    private int orderCount = 0;
    private int TotalOrderCount = 0;
    [HideInInspector] public float waitingTime = 0f;
    private float TotalTime = 0f;

    void Start()
    {
        // Canvas에서 Text 객체 찾기
        orderText = GameObject.Find("OrderText").GetComponent<Text>();
        TotalOrderText = GameObject.Find("TotalOrderText").GetComponent<Text>();
        waitingTimeText = GameObject.Find("SingleWT").GetComponent<Text>();
        simulationTimeText = GameObject.Find("TotalTime").GetComponent<Text>();
        // 시작할 때 UI 초기화
        UpdateOrderCount();
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
        UpdateTotalTime();
    }

    void UpdateTotalTime()
    {
        simulationTimeText.text = TotalTime.ToString("F1");
    }

    void UpdateOrderCount()
    {
        // UI Text 업데이트
        orderText.text = orderCount.ToString();
        TotalOrderText.text = TotalOrderCount.ToString();
    }

    // 프리팹 도착 시 호출되는 메서드
    public void OnPrefabArrival()
    {
        // 주문 수 증가 및 UI 업데이트
        IncreaseOrderCount();

        // 일정 시간 후에 주문 처리를 위한 코루틴 시작
        StartCoroutine(CompleteOrderAfterDelay());
    }

    IEnumerator CompleteOrderAfterDelay()
    {
        // 일정 시간 대기 (예: 5초)
        yield return new WaitForSeconds(7f);

        // 주문 수 감소 및 UI 업데이트
        DecreaseOrderCount();
    }

    // 주문 수를 증가시키는 메서드
    void IncreaseOrderCount()
    {
        orderCount++;
        TotalOrderCount++;
        UpdateOrderCount();
    }

    // 주문 수를 감소시키는 메서드
    void DecreaseOrderCount()
    {
        if (orderCount > 0)
        {
            orderCount--;

            // 주문 수 감소 후 UI 업데이트
            UpdateOrderCount();
        }
    }
}