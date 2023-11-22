using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    private Text orderText; // UI Text ��ü�� ������ ����
    private Text TotalOrderText; // TotalOrderText
    [HideInInspector] public Text waitingTimeText;
    private Text simulationTimeText; // �ùķ��̼� �ð�

    private int orderCount = 0;
    private int TotalOrderCount = 0;
    [HideInInspector] public float waitingTime = 0f;
    private float TotalTime = 0f;

    void Start()
    {
        // Canvas���� Text ��ü ã��
        orderText = GameObject.Find("OrderText").GetComponent<Text>();
        TotalOrderText = GameObject.Find("TotalOrderText").GetComponent<Text>();
        waitingTimeText = GameObject.Find("SingleWT").GetComponent<Text>();
        simulationTimeText = GameObject.Find("TotalTime").GetComponent<Text>();
        // ������ �� UI �ʱ�ȭ
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
        // UI Text ������Ʈ
        orderText.text = orderCount.ToString();
        TotalOrderText.text = TotalOrderCount.ToString();
    }

    // ������ ���� �� ȣ��Ǵ� �޼���
    public void OnPrefabArrival()
    {
        // �ֹ� �� ���� �� UI ������Ʈ
        IncreaseOrderCount();

        // ���� �ð� �Ŀ� �ֹ� ó���� ���� �ڷ�ƾ ����
        StartCoroutine(CompleteOrderAfterDelay());
    }

    IEnumerator CompleteOrderAfterDelay()
    {
        // ���� �ð� ��� (��: 5��)
        yield return new WaitForSeconds(7f);

        // �ֹ� �� ���� �� UI ������Ʈ
        DecreaseOrderCount();
    }

    // �ֹ� ���� ������Ű�� �޼���
    void IncreaseOrderCount()
    {
        orderCount++;
        TotalOrderCount++;
        UpdateOrderCount();
    }

    // �ֹ� ���� ���ҽ�Ű�� �޼���
    void DecreaseOrderCount()
    {
        if (orderCount > 0)
        {
            orderCount--;

            // �ֹ� �� ���� �� UI ������Ʈ
            UpdateOrderCount();
        }
    }
}