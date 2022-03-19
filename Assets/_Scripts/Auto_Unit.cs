using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class Auto_Unit : MonoBehaviour
{
    [Header("Properties:")]
    public NavMeshAgent navmeshAuto;
    public Outline outline;
    public List<Auto_Unit_SO> AUTO_UNIT_SO_LIST = new List<Auto_Unit_SO>();
    public Auto_Unit_SO autoUnitSO;
    public GameObject[] autoBodys;

    [Header("Headlights:")]
    public GameObject[] autoHeadLamps;
    public GameObject[] autoHeadLights;
    public Material autoHeadLamps_ON;
    public Material autoHeadLamps_OFF;

    [Header("Breaklights:")]
    public GameObject[] autoBreakLamps;
    public Material autoBreakLamps_ON;
    public Material autoBreakLamps_OFF;

    public void Awake()
    {
        int index = Random.Range(0, AUTO_UNIT_SO_LIST.Count);//Get a random scriptable object for vehicle
        autoUnitSO = AUTO_UNIT_SO_LIST[index];//Select SO for unit
        autoUnitSO.ID = GetInstanceID();//GEt unit unique ID
        GetProfile();
        //AUTO_UNIT_SO_LIST.Remove(autoUnitSO);//not surrently used
    }
    private void FixedUpdate()
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
    }

    public void GetProfile()
    {
        int m = Random.Range(0, GameData.AUTO_MODEL_NAMES.Length);//Get a random name for auto unit
        autoUnitSO.Model = GameData.AUTO_MODEL_NAMES[m];//Assign name to SO
        autoUnitSO.Body = Random.Range(0, autoBodys.Length);//Get random body frame
        autoBodys[autoUnitSO.Body].SetActive(true);//Turn on selected body
    }

    private void OnMouseOver()//Show model name
    {
        print(autoUnitSO.Model);//Print name to console
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    private void OnMouseUp()//Select  unit = not currently used
    {
        autoUnitSO.isSelected = true;
    }
}
