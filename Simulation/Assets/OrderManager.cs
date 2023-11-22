using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public Text orderText; // UI Text ��ü�� ������ ����

    private int orderCount = 0;

    void Start()
    {
        // Canvas���� Text ��ü ã��
        orderText = GameObject.Find("OrderText").GetComponent<Text>();

        // ������ �� UI �ʱ�ȭ
        UpdateOrderCount();
    }

    void UpdateOrderCount()
    {
        // UI Text ������Ʈ
        orderText.text = orderCount.ToString();
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