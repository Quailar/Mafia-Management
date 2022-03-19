using UnityEngine;

public class Auto_Base_SO : ScriptableObject
{
    [Header("Profile")]
    public int ID;

    [Header("Location")]
    public Vector3 Position;
    public Vector3 WayPoint;
    public Vector3 Destination;

    [Header("Stats")]
    public float CurrentHitPoints;
    public float MaxHitPoints;
    public float Speed;
    public float NewPrice;
    public float LeasePerMonth;
    public float StolenValue;

    [Header("Team Attributes")]
    public string TeamName;

    [Header("Status")]
    public bool isSelected;

}

