using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IInteractable
{
    public string interactionMessage;
    public RCC_CarControllerV3 carController;
    
    public GameObject player;
    public GameObject playerCamera;
    public GameObject carCamera;
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ShopManager.instance.isShopOpen && !PlayerGarage.instance.isPlayerGarageOpen)
        {
            ExitCar();
        }
    }
    
    public void Interact()
    {
        EnterCar();
    }

    public string GetPromptMessage()
    {
        return interactionMessage;
    }

    private void EnterCar()
    {
        if (!carController.enabled)
        {
            carCamera.SetActive(true);
            player.SetActive(false);
            playerCamera.SetActive(false); 
        
            carController.enabled = true;
            
            carController.GetComponent<Rigidbody>().isKinematic = false;
            carController.handbrakeInput = 0f;
            carController.StartEngine();
            
            
        }
    }

    private void ExitCar()
    {
        if (carController.enabled)
        {
            player.transform.position = carController.transform.position + new Vector3(0.5f, 0,0);
            carCamera.SetActive(false);
            player.SetActive(true);
            playerCamera.SetActive(true);
            
            carController.GetComponent<Rigidbody>().isKinematic = true;
            carController.handbrakeInput = 100f; 
            carController.KillEngine();
            
            Invoke("DisableCarController", 1f);
        }
    }

    private void DisableCarController()
    {
        carController.enabled = false;
    }
    
}
