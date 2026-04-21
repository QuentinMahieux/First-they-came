using System;using UnityEngine;

[CreateAssetMenu(fileName = "ProhibitionNumberData", menuName = "Scriptable Objects/Prohibition/ProhibitionNumberData")]
public class ProhibitionNumberData : ProhibitionData
{
    [Header("Prohibition Number Data")]
    public NumberType numberType;
    public symbolType symbolType;
    public float number;
}
public enum NumberType
{
    speedLimit,
    age
}