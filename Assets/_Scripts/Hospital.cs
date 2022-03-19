using UnityEngine;
using System.Collections.Generic;
public class Hospital : MonoBehaviour
{
    public GameData gameData;
    public Outline outline;
    public List<Hospital_SO> HOSPITAL_SO = new List<Hospital_SO>();
    public Hospital_SO hospitalSO;



    public void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();
        GetProfile();
    }

    public void GetProfile()
    {
        int randomSO = Random.Range(0, HOSPITAL_SO.Count);
        hospitalSO = HOSPITAL_SO[randomSO];


        hospitalSO.ID = GetInstanceID();
        int bn = Random.Range(0, GameData.LEGAL_BUSINESS_NAMES.Length);
        hospitalSO.LegalBusinessType = "Hospital"; ;

        hospitalSO.MaxHitPoints = Random.Range(80, 120);
        hospitalSO.CurrentHitPoints = hospitalSO.MaxHitPoints;
        hospitalSO.Level = 0;

        hospitalSO.Income = Random.Range(2000, 5000);
        hospitalSO.Expenses = Random.Range(500, 2000); ;
        hospitalSO.Cash = hospitalSO.Income - hospitalSO.Expenses;

        hospitalSO.TeamName = "Business";
    }

    private void OnMouseOver()
    {
        print(hospitalSO.LegalBusinessType);
        print(hospitalSO.ManagerName);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    private void OnMouseUp()
    {
        hospitalSO.isSelected = true;
    }
}
