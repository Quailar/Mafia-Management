using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class Business_Unit : MonoBehaviour
{
    public GameData gameData;
    public List<Business_Base_SO> BUSINESS_BASE_SO_LIST = new List<Business_Base_SO>();
    public Business_Base_SO businessSO;
    public List<Manager_Unit_SO> BUSINESS_MANAGERS_LIST = new List<Manager_Unit_SO>();
    public Manager_Unit_SO buildingManager;


    public void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();

        GetProfile();

    }

    public void GetProfile()
    {
        int randomSO = Random.Range(0, BUSINESS_BASE_SO_LIST.Count);
        businessSO = BUSINESS_BASE_SO_LIST[randomSO];
        int randomMgr = Random.Range(0, BUSINESS_MANAGERS_LIST.Count);
        buildingManager = BUSINESS_MANAGERS_LIST[randomMgr];

        businessSO.ID = GetInstanceID();
        int bn = Random.Range(0, GameData.LEGAL_BUSINESS_NAMES.Length);
        businessSO.LegalBusinessType = GameData.LEGAL_BUSINESS_NAMES[bn];
        businessSO.ManagerName = buildingManager.FirstName + " " + buildingManager.LastName;
        businessSO.MaxHitPoints = Random.Range(80, 120);
        businessSO.CurrentHitPoints = businessSO.MaxHitPoints;
        businessSO.Level = 0;

        businessSO.Income = Random.Range(2000, 5000);
        businessSO.Expenses = Random.Range(500, 2000); ;
        businessSO.Cash = businessSO.Income - businessSO.Expenses;

        businessSO.TeamName = "Business";


    }

    private void OnMouseOver()
    {
        print(businessSO.LegalBusinessType);
        print(businessSO.ManagerName);
    }

    private void OnMouseUp()
    {
        businessSO.isSelected = true;

    }


}
