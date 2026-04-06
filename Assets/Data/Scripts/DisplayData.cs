using UnityEngine;

[CreateAssetMenu(fileName = "DisplayData", menuName = "Scriptable Objects/DisplayData")]
public class DisplayData : ScriptableObject
{
    public int id;
    public Sprite driverSprite;
    public Sprite identitySprite;
}
