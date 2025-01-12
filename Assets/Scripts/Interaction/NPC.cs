using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public ShopManager shopManager;
    public string interactionMessage;

    public void Interact()
    {
        shopManager.OpenShop();
    }

    public string GetPromptMessage()
    {
        return interactionMessage;
    }
    
}

