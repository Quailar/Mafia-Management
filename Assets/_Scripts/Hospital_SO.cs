using UnityEngine;

[CreateAssetMenu(fileName = "Hospital", menuName = "Create Hospital", order = 0)]

public class Hospital_SO : ScriptableObject
{
    [Header("Profile")]
    public float ID;
    public string LegalBusinessType;
    public string IllegalBusinessType;
    public string ManagerName;


    [Header("Location")]
    public Vector3 Location;


    [Header("Stats")]
    public float CurrentHitPoints;
    public float MaxHitPoints;
    public float Level;
    public float Income;
    public float Expenses;
    public float Cash;



    [Header("Team Attributes")]
    public string TeamName;
    public int Rank;

    public bool isSelected;


}

