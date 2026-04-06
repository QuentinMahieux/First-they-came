using UnityEngine;

[CreateAssetMenu(fileName = "ProhibitionData", menuName = "Scriptable Objects/Prohibition/ProhibitionData", order = 1)]
public class ProhibitionData : ScriptableObject
{
    
}

public enum symbolType
{
    superieur,
    inferieur,
    egal // Tous les animaux sont égaux, mais certains animaux sont plus égaux que d'autres 
}