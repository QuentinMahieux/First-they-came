using UnityEngine;

[CreateAssetMenu(fileName = "DriverData", menuName = "Scriptable Objects/DriverData")]
public class DriverData : ScriptableObject
{
    [Header("Car")] 
    [Tooltip("Vitesse a laquel roule la voiture")]
    public float speed;
    [Tooltip("Numero de plaque d'imatrculation de la voiture")]
    public string plaque = "AA-000-AA";
    [Tooltip("Nationalité de la voiture")]
    public GameObject carPrefab;
    public DisplayData displayDataCar;
    
    [Header("Identity")]
    public string firstName;
    public string familyName;
    public DisplayData displayDataIdentity;
    public Nationality nationality;
    public Gender gender;
    public int age;
    public Vector3 validity = new Vector3(29, 12, 2006);

}

public enum Nationality
{
    France,
    Italy,
    Espagne
}

public enum Gender
{
    Male,
    Female,
    Nb
}

