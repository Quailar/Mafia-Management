using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class Auto_Police_Unit : MonoBehaviour
{
    [Header("Properties:")]
    public NavMeshAgent navmeshAuto;
    public Auto_Unit_SO autoUnitSO;
    public List<Auto_Unit_SO> AUTO_UNIT_SO_LIST = new List<Auto_Unit_SO>();
    public GameObject[] autoBodys;

    [Tooltip("Headlights: Light, Lamps: Objects, Materials: Color On/Off")]
    [Header("Headlights:")]

    public GameObject[] autoHeadLamps;
    public GameObject[] autoHeadLights;
    public Material autoHeadLamps_ON;
    public Material autoHeadLamps_OFF;

    [Tooltip("Lamps: Objects, Materials: Color On/Off")]
    [Header("Breaklights:")]
    public GameObject[] autoBreakLamps;
    public Material autoBreakLamps_ON;
    public Material autoBreakLamps_OFF;

    [Tooltip("Lamps: Objects, Materials: Color On/Off")]
    [Header("Alarm lights:")]
    public bool Alarm;
    public GameObject[] PoliceAlarmLamps;
    public Material policeAlarmBlueLamp_ON;
    public Material policeAlarmRedLamp_ON;
    public Material policeAlarmLamp_OFF;
    public string Model;

    public int Body;
    public void Awake()
    {
        int index = Random.Range(0, AUTO_UNIT_SO_LIST.Count);//Get a random scriptable object for vehicle
        autoUnitSO = AUTO_UNIT_SO_LIST[index];//Select SO for unit
        autoUnitSO.ID = GetInstanceID();//GEt unit unique ID
        GetProfile();
        //AUTO_UNIT_SO_LIST.Remove(autoUnitSO);//not surrently used
    }
    private void Update()
    {
        navmeshAuto.speed = 3.5f * GameData.gameSpeed / 2;
        CheckLights();
    }

    public void CheckLights()
    {
        if (GameData.NightLights)
        {
            autoHeadLamps[0].GetComponent<Renderer>().material = autoHeadLamps_ON;
            autoHeadLamps[1].GetComponent<Renderer>().material = autoHeadLamps_ON;
            autoHeadLights[0].SetActive(true);
            autoHeadLights[1].SetActive(true);
            if (navmeshAuto.speed < .5f)
            {
                autoBreakLamps[0].GetComponent<Renderer>().material = autoBreakLamps_ON;
                autoBreakLamps[1].GetComponent<Renderer>().material = autoBreakLamps_ON;
            }
            else
            {
                autoBreakLamps[0].GetComponent<Renderer>().material = autoBreakLamps_OFF;
                autoBreakLamps[1].GetComponent<Renderer>().material = autoBreakLamps_OFF;
            }
        }
        else
        {
            autoHeadLamps[0].GetComponent<Renderer>().material = autoHeadLamps_OFF;
            autoHeadLamps[1].GetComponent<Renderer>().material = autoBreakLamps_OFF;
            autoHeadLights[0].SetActive(false);
            autoHeadLights[1].SetActive(false);

        }

        if (Alarm)
        {
            float toggle = Mathf.PingPong(1, 1);
            if (toggle == 0)
            {
                PoliceAlarmLamps[0].GetComponent<Renderer>().material = policeAlarmRedLamp_ON;
                PoliceAlarmLamps[1].GetComponent<Renderer>().material = policeAlarmLamp_OFF;
            }
            else
            {
                PoliceAlarmLamps[0].GetComponent<Renderer>().material = policeAlarmLamp_OFF;
                PoliceAlarmLamps[1].GetComponent<Renderer>().material = policeAlarmBlueLamp_ON;
            }
        }
        else
        {
            PoliceAlarmLamps[0].GetComponent<Renderer>().material = policeAlarmLamp_OFF;
            PoliceAlarmLamps[1].GetComponent<Renderer>().material = policeAlarmLamp_OFF;
        }
    }

    public void GetProfile()
    {
        int m = Random.Range(0, GameData.AUTO_MODEL_NAMES.Length);//Get a random name for auto unit
        Model = "Patrol Car";//Assign name to SO
        Body = 0;
        autoBodys[Body].SetActive(true);//Turn on selected body
    }

    private void OnMouseOver()//Show model name
    {
        print(Model);//Print name to console
    }

    private void OnMouseUp()//Select  unit = not currently used
    {
        autoUnitSO.isSelected = true;
    }
}
