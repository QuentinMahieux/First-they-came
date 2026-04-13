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
    public DriveType driveType;
    
    [Header("Identity")]
    public string firstName;
    public string familyName;
    public LicenceType licenceType;
    public DisplayData displayData;
    public Nationality nationality;
    public Gender gender;
    public int age;
    public bool validity;

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
public enum LicenceType
{
    Apprentie,
    Normal,
    Senior
}
public enum DriveType
{
    Triange,
    Carré,
    Rond
}