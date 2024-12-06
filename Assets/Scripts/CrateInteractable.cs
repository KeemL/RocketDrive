using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrateInteractable : MonoBehaviour, IInteractable
{
    public float InteractionRange => 1.5f;

    private bool isPlayerInRange = false;

    [SerializeField] private GameObject containerGameObject;

    private bool readingNote = false;

    void Start()
    {
        //gameObject.SetActive(true);
        containerGameObject.SetActive(false);
        readingNote = false;
    }

    private void Update()
    {

    }

    void Hide()
    {
        containerGameObject.SetActive(false);
    }

    void Show()
    {
        containerGameObject.SetActive(true);
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
        if (readingNote == true)
        {
            Hide();
            readingNote = false;

        }
        else
        {
            Show();
            readingNote = true;
        }


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
