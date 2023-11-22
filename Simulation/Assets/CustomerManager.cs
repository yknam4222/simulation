using System.Collections;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab; // �մ� ������
    public Transform counter; // ī���� ��ġ
    public Transform Spawn;
    public GameObject customersParent; // Customers GameObject �߰�
    private int customerCount = 0; // �� ��ȣ ī��Ʈ ����
    private bool isSimulationRunning = true;

    void Start()
    {
        StartCoroutine(SimulationLoop());
    }

    IEnumerator SimulationLoop()
    {
        while (isSimulationRunning)
        {
            // �ֹ� ���� �� �մ� ����
            SpawnCustomer();

            yield return new WaitForSeconds(5f); // �ֹ� ����: 1��
        }
    }

    void SpawnCustomer()
    {
        // Instantiate customer prefab
        GameObject customer = Instantiate(customerPrefab, Spawn.position, Quaternion.identity);

        if (customersParent != null)
        {
            // Set the customer as a child of the "Customers" GameObject
            customer.transform.parent = customersParent.transform;
        }

        // Assign a unique name to the instantiated customer
        customer.name = "Customer" + (++customerCount);

        // Get the Customer script component
        Customer customerScript = customer.GetComponent<Customer>();
        customerScript.counter = counter;
    }
}
