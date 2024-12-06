using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    public float InteractionRange => 1.5f;

    private bool isPlayerInRange = false;

    public valueSaver script;

    void Start()
    {
        gameObject.SetActive(true);

    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetButton("EKey"))
        {
            CollectCoin();

        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CollectCoin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void CollectCoin()
    {
        // Perform coin collection logic here
        gameObject.SetActive(false); // Disable the coin GameObject
        if (script != null)
        {
            // Increment the global coin count
            valueSaver.coinCount++;
            Debug.Log("Coin collected. Total coins: " + valueSaver.coinCount);
        }
        else
        {
            Debug.LogWarning("Unable to collect coin.");
        }
    }

    public void Interact(Transform interactorTransform)
    {
        CollectCoin();
    }

    public string GetInteractText()
    {
        if (valueSaver.CTSdone)
        {
            return "Collect Coin";
        }
        else
        {
            return null;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }


}