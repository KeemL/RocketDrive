using UnityEngine;

public class lastCoin : MonoBehaviour
{
    private bool isPlayerInRange = false;

    public valueSaver script;

    public GameObject containerGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        containerGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            valueSaver.coinCount++;
            isPlayerInRange = true;
            if (valueSaver.coinCount >= 4)
            {

                containerGameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            containerGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
