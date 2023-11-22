using System.Collections;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab; // 손님 프리팹
    public Transform counter; // 카운터 위치
    public Transform Spawn;
    public GameObject customersParent; // Customers GameObject 추가
    private int customerCount = 0; // 고객 번호 카운트 변수
    private bool isSimulationRunning = true;

    void Start()
    {
        StartCoroutine(SimulationLoop());
    }

    IEnumerator SimulationLoop()
    {
        while (isSimulationRunning)
        {
            // 주문 생성 및 손님 생성
            SpawnCustomer();

            yield return new WaitForSeconds(5f); // 주문 간격: 1분
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
