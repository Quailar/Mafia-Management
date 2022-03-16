using UnityEngine;

[CreateAssetMenu(fileName = "Agent", menuName = "Create Agent Unit", order = 0)]

public class Agent_Unit_SO : Agent_Base_SO
{

    void Awake()
    {
        getStats();
    }

    void getStats()
    {
        MaxHitPoints = Random.Range(80, 120);
        CurrentHitPoints = MaxHitPoints;
        Strength = Random.Range(1, 10);
        Intelligence = Random.Range(1, 10);
        Speed = Random.Range(1, 10);
        Stamina = Random.Range(1, 10);
        Driving = Random.Range(1, 10);
        Unarmed = Random.Range(1, 10);
        FireArms = Random.Range(1, 10);
        Explosives = Random.Range(1, 10);
        Dodge = Random.Range(1, 10);
        Stealth = Random.Range(1, 10);
        Charisma = Random.Range(1, 10);
        Rank = 1;
        TotalStats = MaxHitPoints + Strength + Intelligence + Speed + Driving + Unarmed + FireArms + Explosives + Dodge + Stealth + Charisma;
        CostToHire = TotalStats * Speed;
        PricePerMonth = CostToHire / 10;
        TeamName = "Agent";
    }
}

