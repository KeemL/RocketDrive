using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrateInteractable : MonoBehaviour, IInteractable
{
    public float InteractionRange => 1.5f;

    private bool isPlayerInRange = false;

    [SerializeField] private GameObject containerGameObject;

    void Start()
    {
        //gameObject.SetActive(true);
        containerGameObject.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetButton("EKey"))
        {
            ReadNote();

        }
        // if (valueSaver.happyMeal && Input.GetButton("EKey"))
        // {
        //     SceneManager.LoadScene("Outdoors");
        // }

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

    private void ReadNote()
    {

        Debug.Log("reading note...");

        containerGameObject.SetActive(true);


    }

    public void Interact(Transform interactorTransform)
    {
        ReadNote();
    }

    public string GetInteractText()
    {
        return "Read Note";
    }

    public Transform GetTransform()
    {
        return transform;
    }

}
