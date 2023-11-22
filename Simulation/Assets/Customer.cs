using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float moveSpeed = 2f; // �մ� �̵� �ӵ�
    public Transform counter; // ī������ ��ġ
    public float customerSpacing = 1.5f; // �մ� ����

    private bool isMoving = true; // �ʱ⿡ �̵� ���·� ����
    private OrderManager orderManager;
    private bool orderCompleted = false;
    void Start()
    {
        orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveToCounter();
        }
        CheckSpacing();
    }

    void MoveToCounter()
    {
        Vector3 targetPosition = new Vector3(counter.position.x, transform.position.y, counter.position.z);

        // �տ� �մ��� ������ �̵� ���
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // �������� �����ϸ� �̵��� ����ϴ�.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;

            if (!orderCompleted)
            {
                // �մ��� ī���Ϳ� �������� ���� ���� �߰� (�ֹ� ���� ��)
                orderManager.OnPrefabArrival();

                // ������ ���� (��: 3�� �Ŀ�)
                StartCoroutine(RemovePrefabAfterDelay());
                orderCompleted = true; // �ֹ� �Ϸ� �÷��׸� ����
            }
        }
    }
    IEnumerator RemovePrefabAfterDelay()
    {
        yield return new WaitForSeconds(7f); // 3�� ���
        Destroy(gameObject); // ������ ����
    }
    void CheckSpacing()
    {
        // ĸ���� ���߾ӿ��� ����ĳ��Ʈ �� ǥ��
        Debug.DrawRay(transform.position, transform.forward * customerSpacing, Color.red);

        // �ٸ� �մ��� �տ� �ִ��� Ȯ���ϰ� ��� ��ġ ����
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, customerSpacing))
        {
            // �տ� �ٸ� �մ��� ������ ����
            isMoving = false;
            return;
        }
        else
        {
            isMoving = true;
        }
    }
}