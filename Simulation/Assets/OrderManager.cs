using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Text orderText; // UI Text 객체를 저장할 변수

    private int orderCount = 0;

    void Start()
    {
        // Canvas에서 Text 객체 찾기
        orderText = GameObject.Find("OrderText").GetComponent<Text>();

        // 시작할 때 UI 초기화
        UpdateOrderCount();
    }

    void UpdateOrderCount()
    {
        // UI Text 업데이트
        orderText.text = orderCount.ToString();
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