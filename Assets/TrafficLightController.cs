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
    public int trafficSignal;



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

        StartCoroutine("TrafficLightsCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        print($"{trafficPoles.Count} , {redTrafficLights.Count} , {greenTrafficLights.Count} , {yellowTrafficLights.Count}");
        print($"{agentSpawnPoints.Count} , {autoSpawnPoints.Count}");
        print($"{streetLamps.Count} , {streetLampBulb.Count} , {streetLampPointLight.Count} , {streetLampSpotLight.Count}");
    }

    IEnumerator TrafficLightsCoroutine()
    {
        if (trafficSignal <= 2)
        {
            ChangeTrafficSignal(2);
            yield return new WaitForSecondsRealtime(5);
            trafficSignal--;
        }
        else if (trafficSignal == 1)
        {
            ChangeTrafficSignal(1);
            yield return new WaitForSecondsRealtime(1);
            trafficSignal--;
        }
        else
        {
            ChangeTrafficSignal(0);
            yield return new WaitForSecondsRealtime(3);
            trafficSignal = 2;
        }
    }

    void ChangeTrafficSignal(float signal)
    {
        if (signal == 0)//Red traffic light signal
        {
            foreach (GameObject light in redTrafficLights)
            {
                light.GetComponent<MeshRenderer>().material = redTrafficLight_ON;
            }
        }
        else
        {
            foreach (GameObject light in redTrafficLights)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;
            }
        }
        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------
        if (signal == 1)//Yellow traffic light signal
        {
            foreach (GameObject light in yellowTrafficLights)
            {
                light.GetComponent<MeshRenderer>().material = yellowTrafficLight_ON;
            }
        }
        else
        {
            foreach (GameObject light in yellowTrafficLights)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;
            }
        }
        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------
        if (signal == 2)//Green traffic light signal
        {
            foreach (GameObject light in greenTrafficLights)
            {
                light.GetComponent<MeshRenderer>().material = greenTrafficLight_ON;
            }
        }
        else
        {
            foreach (GameObject light in greenTrafficLights)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;
            }
        }
    }
}
