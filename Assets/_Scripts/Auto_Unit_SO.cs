using UnityEngine;



//This is the SO setup for auto indicidual stats are set here instead of Base SO
[CreateAssetMenu(fileName = "Auto_Unit_SO", menuName = "Create Auto Unit", order = 0)]
public class Auto_Unit_SO : Auto_Base_SO
{

    void Awake()
    {
        getStats();
    }

    void getStats()
    {
        MaxHitPoints = Random.Range(300, 500);//Set hit point
        CurrentHitPoints = MaxHitPoints;//Set current hit points
        Speed = Random.Range(1, 10);//Set unit speed

        NewPrice = Random.Range(500, 2000);//Set purchase price
        LeasePerMonth = NewPrice / 10;//Set Lease price
        StolenValue = (float)(NewPrice * .35);//Set Scrap value
        TeamName = "Auto";//Set team name
    }
}

