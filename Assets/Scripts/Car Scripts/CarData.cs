using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car System/Car Data")]
public class CarData : ScriptableObject
{
    public string carModel;
    public float topSpeed; 
    public float basePrice; 
    public float condition = 100f;
}