using UnityEngine;

public class Manager_Base_SO : ScriptableObject
{
    [Header("Profile")]
    public float ID;
    public string Gender;
    public string FirstName;
    public string LastName;
    public string NickName;
    public int Body;
    public int Head;
    public int Weapon;

    [Header("Location")]
    public Vector3 Position;

    [Header("Stats")]
    public float CurrentHitPoints;
    public float MaxHitPoints;
    public float Strength;
    public float Intelligence;
    public float Speed;
    public float Stamina;
    public float Driving;
    public float Unarmed;
    public float FireArms;
    public float Explosives;
    public float Dodge;
    public float Stealth;
    public float Charisma;
    public float TotalStats;
    public float CostToHire;
    public float PricePerMonth;

    [Header("Team Attributes")]
    public string TeamName;

    [Header("Status")]
    public bool isLuitenant;
    public bool isSelected;
    public bool isIdle;
    public bool isWalking;
    public bool isRunning;
    public bool isFleeing;
    public bool isInCover;
    public bool isThrowing;
    public bool isPunching;
    public bool isStabbing;
    public bool isShooting;
    public bool isTalking;
    public bool isHurt;
    public bool isDead;
}

