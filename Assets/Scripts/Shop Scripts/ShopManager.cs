using Cinemachine;
using TMPro;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    
    public GameObject shopUI;
    public PlayerMovement playerMovement;
    public CinemachineFreeLook playerCamera;
    public TextMeshProUGUI infoText;
    public bool isShopOpen;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }    
    }

    public void OpenShop()
    {
        if (!PlayerGarage.instance.isPlayerGarageOpen)
        {
            shopUI.SetActive(true);
            playerMovement.enabled = false;
            playerCamera.enabled = false;

            isShopOpen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
        playerMovement.enabled = true;
        playerCamera.enabled = true;

        isShopOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BuyCar(CarDataManager car)
    {
        FindObjectOfType<PlayerGarage>().AddCar(car);
        infoText.text = car.carData.carModel + " bought!";
    }
    
}
