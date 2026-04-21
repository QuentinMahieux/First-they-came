using UnityEngine;

[CreateAssetMenu(fileName = "DayData", menuName = "Scriptable Objects/DayData")]
public class DayData : ScriptableObject
{
    [Tooltip("Toute les voitures (elle apparatront dans l'ordre")]public DriverData[] driverDatas;
    [Tooltip("Intervale d'appartion entre 2 voiture")]public float intervaToSpawn;
}
