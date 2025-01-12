using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class InteractManager : MonoBehaviour
{
    [FormerlySerializedAs("player")] public Transform orientation; 
    public float interactRange = 3f; 
    public TextMeshProUGUI promptText;

    private IInteractable currentInteractable;

    void Update()
    {
        CheckForInteractable();
        HandleInteraction();
    }

    private void CheckForInteractable()
    {
        Ray ray = new Ray(orientation.position, orientation.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                promptText.text = interactable.GetPromptMessage();
                promptText.gameObject.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        promptText.gameObject.SetActive(false);
    }

    private void HandleInteraction()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }
}

