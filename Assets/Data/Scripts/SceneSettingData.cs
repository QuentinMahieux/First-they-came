using UnityEngine;

[CreateAssetMenu(fileName = "SceneSettingData", menuName = "Scriptable Objects/SceneSettingData")]
public class SceneSettingData : ScriptableObject
{
    [Header("Drive")] public float divisionSpeedCar = 13.5f;
}
