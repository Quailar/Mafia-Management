using UnityEngine;
using System.Collections.Generic;
public class Police_Station : MonoBehaviour
{
    public GameData gameData;
    public Outline outline;
    public List<Police_Station_SO> Police_Station_SO = new List<Police_Station_SO>();
    public Police_Station_SO policeStation;



    public void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();
        GetProfile();
    }

    public void GetProfile()
    {
        int randomSO = Random.Range(0, Police_Station_SO.Count);
        policeStation = Police_Station_SO[randomSO];


        policeStation.ID = GetInstanceID();
        int bn = Random.Range(0, GameData.LEGAL_BUSINESS_NAMES.Length);
        policeStation.LegalBusinessType = "Police Station"; ;

        policeStation.MaxHitPoints = Random.Range(80, 120);
        policeStation.CurrentHitPoints = policeStation.MaxHitPoints;
        policeStation.Level = 0;

        policeStation.Income = Random.Range(2000, 5000);
        policeStation.Expenses = Random.Range(500, 2000); ;
        policeStation.Cash = policeStation.Income - policeStation.Expenses;

        policeStation.TeamName = "Business";
    }

    private void OnMouseOver()
    {
        print(policeStation.LegalBusinessType);
        print(policeStation.ManagerName);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    private void OnMouseUp()
    {
        policeStation.isSelected = true;
    }
}
