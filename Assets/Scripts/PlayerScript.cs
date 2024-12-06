using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButton("EKey"))
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                ;
                interactable.Interact(transform);
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        float interactRange = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        List<IInteractable> interactableList = new List<IInteractable>();
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        if (interactableList.Count == 0)
        {
            // No interactable NPCs found
            return null;
        }

        IInteractable closestInteractable = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (IInteractable interactable in interactableList)
        {
            if (interactable.GetInteractText() != null)
            {
                float distanceSqr = (transform.position - interactable.GetTransform().position).sqrMagnitude;
                if (distanceSqr < closestDistanceSqr)
                {
                    closestDistanceSqr = distanceSqr;
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}

