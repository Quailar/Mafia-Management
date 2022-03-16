using UnityEngine;

public class Agent_Base_SO : ScriptableObject
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
    public Vector3 WayPoint;
    public Vector3 Destination;

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
    public int Rank;
    public string TeamAbility;
    public int[] TeamRelations = { 1, 3, 5, 7, 9 };

    [Header("Status")]
    public bool isLuitenant;
    public bool isSelected;
    public bool isIdle;
    public bool isWalking;
    public bool isRunning;
    public bool isDriving;
    public bool isFleeing;
    public bool isInCover;
    public bool isThrowing;
    public bool isPunching;
    public bool isStabbing;
    public bool isShooting;
    public bool isDealing;
    public bool isBribing;
    public bool isRecruiting;
    public bool isStealing;
    public bool isTraining;
    public bool isTalking;
    public bool isJailed;
    public bool isHurt;
    public bool isHospitalized;
    public bool isDead;


}

