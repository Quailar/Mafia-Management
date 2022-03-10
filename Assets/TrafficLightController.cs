using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{

    public List<GameObject> trafficPoles;
    public List<GameObject> redTrafficLights;
    public List<GameObject> greenTrafficLights;
    public List<GameObject> yellowTrafficLights;

    public Material redTrafficLight_ON;
    public Material greenTrafficLight_ON;
    public Material yellowTrafficLight_ON;
    public Material trafficLight_OFF;
    public float trafficSignal;



    public List<GameObject> agentSpawnPoints;
    public List<GameObject> autoSpawnPoints;

    public List<GameObject> streetLamps;

    public List<GameObject> streetLampBulb;
    public List<GameObject> streetLampPointLight;
    public List<GameObject> streetLampSpotLight;

    // Start is called before the first frame update
    private void Awake()
    {

        trafficPoles.AddRange(GameObject.FindGameObjectsWithTag("TAG:TrafficLight"));
        redTrafficLights.AddRange(GameObject.FindGameObjectsWithTag("TAG:RedLightLamp"));
        greenTrafficLights.AddRange(GameObject.FindGameObjectsWithTag("TAG:GreenLightLamp"));
        yellowTrafficLights.AddRange(GameObject.FindGameObjectsWithTag("TAG:YellowLightLamp"));
        agentSpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("TAG:AgentSpawnPoint"));
        autoSpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("TAG:AutoSpawnPoint"));

        streetLamps.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLampPole"));
        streetLampBulb.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLamp"));
        streetLampPointLight.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLampPointLight"));
        streetLampSpotLight.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLampSpotLight"));


    }

    // Update is called once per frame
    void LateUpdate()
    {
        InvokeRepeating("ChangeTrafficSignal", 1f, 1f);
    }


    IEnumerator ChangeTrafficSignal()
    {

        if (trafficSignal == 2)
        {
            GreenLight_ON();
            RedLight_OFF();
            YellowLight_OFF();
            print("GreenLight");
            yield return new WaitForSeconds(5);
            trafficSignal--;
        }
        else if (trafficSignal == 1)
        {
            GreenLight_OFF();
            RedLight_OFF();
            YellowLight_ON();
            print("YellowLight");
            yield return new WaitForSeconds(1);
            trafficSignal--;
        }
        else if (trafficSignal == 0)
        {
            GreenLight_OFF();
            RedLight_ON();
            YellowLight_OFF();
            print("RedLight");
            yield return new WaitForSeconds(3);
            trafficSignal--;
        }


        if (trafficSignal <= 0) { trafficSignal = 2; }

    }
    void RedLight_ON()
    {
        foreach (GameObject light in redTrafficLights)
        {
            light.GetComponent<MeshRenderer>().material = redTrafficLight_ON;


        }

    }
    void YellowLight_ON()
    {
        foreach (GameObject light in yellowTrafficLights)
        {
            light.GetComponent<MeshRenderer>().material = yellowTrafficLight_ON;


        }

    }
    void GreenLight_ON()
    {
        foreach (GameObject light in greenTrafficLights)
        {
            light.GetComponent<MeshRenderer>().material = greenTrafficLight_ON;


        }

    }
    //-----------------------------------------------------------------------------------------
    void RedLight_OFF()
    {
        foreach (GameObject light in redTrafficLights)
        {
            light.GetComponent<MeshRenderer>().material = trafficLight_OFF;
        }

    }
    void YellowLight_OFF()
    {
        foreach (GameObject light in yellowTrafficLights)
        {
            light.GetComponent<MeshRenderer>().material = trafficLight_OFF;
        }

    }
    void GreenLight_OFF()
    {
        foreach (GameObject light in greenTrafficLights)
        {
            light.GetComponent<MeshRenderer>().material = trafficLight_OFF;
        }

    }
}
