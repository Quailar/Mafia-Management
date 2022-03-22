using UnityEngine;
using System.Collections.Generic;
public class Fire_Station : MonoBehaviour
{
    public GameData gameData;
    public Outline outline;
    public List<Fire_Station_SO> FIRE_STATION_SO = new List<Fire_Station_SO>();
    public Fire_Station_SO fireStation;



    public void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();
        GetProfile();
    }

    public void GetProfile()
    {
        int randomSO = Random.Range(0, FIRE_STATION_SO.Count);
        fireStation = FIRE_STATION_SO[randomSO];

        fireStation.ID = GetInstanceID();
        int bn = Random.Range(0, GameData.LEGAL_BUSINESS_NAMES.Length);
        fireStation.LegalBusinessType = "Fire Station";

        fireStation.MaxHitPoints = Random.Range(80, 120);
        fireStation.CurrentHitPoints = fireStation.MaxHitPoints;
        fireStation.Level = 0;

        fireStation.Income = Random.Range(2000, 5000);
        fireStation.Expenses = Random.Range(500, 2000); ;
        fireStation.Cash = fireStation.Income - fireStation.Expenses;
    }

    private void OnMouseOver()
    {
        print(fireStation.LegalBusinessType);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    private void OnMouseUp()
    {
        fireStation.isSelected = true;
    }
}
