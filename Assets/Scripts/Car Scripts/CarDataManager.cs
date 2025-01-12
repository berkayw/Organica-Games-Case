using System;
using TMPro;
using UnityEngine;

public class CarDataManager : MonoBehaviour
{
    public CarData carData;
    
    public TextMeshProUGUI carModel;
    public TextMeshProUGUI topSpeed;
    public TextMeshProUGUI basePrice;
    public TextMeshProUGUI condition;
    
    private void Start()
    {
        carModel.text =  carData.carModel;
        topSpeed.text = "Top Speed: " + carData.topSpeed + " km/h";
        basePrice.text = "Price: " + carData.basePrice + " $";
        condition.text = "Condition: " + "%" + carData.condition;
    }

    
    
}
