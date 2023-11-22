using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public float moveSpeed = 2f; // 손님 이동 속도
    public Transform counter; // 카운터의 위치
    public float customerSpacing = 1.5f; // 손님 간격

    private bool isMoving = true; // 초기에 이동 상태로 설정
    private OrderManager orderManager;
    private bool orderCompleted = false; //주문완료 플래그
    private bool waittingTrigger = false;

    void Start()
    {
        orderManager = GameObject.Find("GameManager").GetComponent<OrderManager>();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveToCounter();
        }
        if(!isMoving && !waittingTrigger)
        {
            orderManager.waitingTime += Time.deltaTime;
            UpdateWaitingTime();
        }
        
        CheckSpacing();

    }

    void MoveToCounter()
    {
        Vector3 targetPosition = new Vector3(counter.position.x, transform.position.y, counter.position.z);

        // 앞에 손님이 없으면 이동 계속
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 목적지에 도착하면 이동을 멈춥니다.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;

            if (!orderCompleted)
            {
                // 손님이 카운터에 도착했을 때의 로직 추가 (주문 생성 등)
                orderManager.OnPrefabArrival();

                // 프리팹 제거 (예: 3초 후에)
                StartCoroutine(RemovePrefabAfterDelay());
                orderCompleted = true; // 주문 완료 플래그를 설정
            }
        }
    }
    IEnumerator RemovePrefabAfterDelay()
    {
        yield return new WaitForSeconds(7f); // 3초 대기
        Destroy(gameObject); // 프리팹 제거
        waittingTrigger = true; //주문 받고 나가면 waitingtime 종료
    }
    void CheckSpacing()
    {
        // 캡슐의 정중앙에서 레이캐스트 선 표시
        Debug.DrawRay(transform.position, transform.forward * customerSpacing, Color.red);

        // 다른 손님이 앞에 있는지 확인하고 대상 위치 조정
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, customerSpacing))
        {
            // 앞에 다른 손님이 있으면 멈춤
            isMoving = false;
            return;
        }
        else
        {
            isMoving = true;
        }
    }

    void UpdateWaitingTime()
    {
        orderManager.waitingTimeText.text = orderManager.waitingTime.ToString("F1");
    }
}