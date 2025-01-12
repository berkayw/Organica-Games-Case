using System;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class PlayerGarage : MonoBehaviour
{
    public static PlayerGarage instance;
    
    public GameObject GarageUI;
    public List<CarDataManager> ownedCars = new List<CarDataManager>();
    public GameObject carItemPrefab;
    public Transform carItemParentTransform;
    public PlayerMovement playerMovement;
    public CinemachineFreeLook playerCamera;
    public bool isPlayerGarageOpen;
    
    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            OpenGarage();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGarage();
        }    
    }

    public void AddCar(CarDataManager car)
    {
        ownedCars.Add(car);
        
        //Adding car to garage ui
        GameObject carItem = Instantiate(carItemPrefab, carItemParentTransform);
        carItem.GetComponent<CarDataManager>().carData = car.carData;
        
    }
    
    private void OpenGarage()
    {
        if (!ShopManager.instance.isShopOpen)
        {
            GarageUI.SetActive(true);
        
            playerMovement.enabled = false;
            playerCamera.enabled = false;

            isPlayerGarageOpen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    private void CloseGarage()
    {
        GarageUI.SetActive(false);
        
        playerMovement.enabled = true;
        playerCamera.enabled = true;

        isPlayerGarageOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

