using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TrafficLightController : MonoBehaviour
{

    public List<GameObject> trafficPoles;
    public List<GameObject> redTrafficLightsNorthSouth;
    public List<GameObject> greenTrafficLightsNorthSouth;
    public List<GameObject> yellowTrafficLightsNorthSouth;
    public List<GameObject> redTrafficLightsEastWest;
    public List<GameObject> greenTrafficLightsEastWest;
    public List<GameObject> yellowTrafficLightsEastWest;

    public Material redTrafficLight_ON;
    public Material greenTrafficLight_ON;
    public Material yellowTrafficLight_ON;
    public Material trafficLight_OFF;
    public int trafficSignalNorthSouth;
    public int trafficSignalEastWest;
    public int dirSwitch = 0;

    bool RedLightNorthSouth_ON;
    bool YellowLightNorthSouth_ON;
    bool GreenLightNorthSouth_ON;
    bool RedLightEastWest_ON;
    bool YellowLightEastWest_ON;
    bool GreenLightEastWest_ON;



    public List<GameObject> agentSpawnPoints;
    public List<GameObject> autoSpawnPoints;
    public List<GameObject> streetLamps;
    public List<GameObject> streetLampBulb;
    public List<GameObject> streetLampPointLight;
    public List<GameObject> streetLampSpotLight;





    private void Awake()
    {

        trafficPoles.AddRange(GameObject.FindGameObjectsWithTag("TAG:TrafficLight"));

        redTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TAG:RedLightLampNorthSouth"));
        greenTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TAG:GreenLightLampNorthSouth"));
        yellowTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TAG:YellowLightLampNorthSouth"));

        redTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TAG:RedLightLampEastWest"));
        greenTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TAG:GreenLightLampEastWest"));
        yellowTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TAG:YellowLightLampEastWest"));

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
        Timer(dirSwitch);
    }
    void Timer(int signal)
    {
        if (dirSwitch == 0)
        {
            trafficSignalNorthSouth++;
            if (trafficSignalNorthSouth < 50)
            {
                GreenLightNorthSouth_ON = true;
                YellowLightNorthSouth_ON = false;
                RedLightNorthSouth_ON = false;
            }
            else if (trafficSignalNorthSouth < 70)
            {
                GreenLightNorthSouth_ON = false;
                YellowLightNorthSouth_ON = true;
                RedLightNorthSouth_ON = false;
            }
            else if (trafficSignalNorthSouth >= 70)
            {
                GreenLightNorthSouth_ON = false;
                YellowLightNorthSouth_ON = false;
                RedLightNorthSouth_ON = true;
                dirSwitch = 1;
                trafficSignalNorthSouth = 0;
            }

        }
        else
        {
            trafficSignalEastWest++;
            if (trafficSignalEastWest < 50)
            {
                GreenLightEastWest_ON = true;
                YellowLightEastWest_ON = false;
                RedLightEastWest_ON = false;
            }
            else if (trafficSignalEastWest < 70)
            {
                GreenLightEastWest_ON = false;
                YellowLightEastWest_ON = true;
                RedLightEastWest_ON = false;
            }
            else if (trafficSignalEastWest >= 70)
            {
                GreenLightEastWest_ON = false;
                YellowLightEastWest_ON = false;
                RedLightEastWest_ON = true;
                dirSwitch = 0;
                trafficSignalEastWest = 0;
            }
        }

        CheckLight();
    }



    void CheckLight()
    {
        if (RedLightNorthSouth_ON)
        {
            foreach (GameObject light in redTrafficLightsNorthSouth)
            {
                light.GetComponent<MeshRenderer>().material = redTrafficLight_ON;


            }

        }
        else
        {
            foreach (GameObject light in redTrafficLightsNorthSouth)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;


            }
        }




        if (YellowLightNorthSouth_ON)
        {
            foreach (GameObject light in yellowTrafficLightsNorthSouth)
            {
                light.GetComponent<MeshRenderer>().material = yellowTrafficLight_ON;


            }

        }
        else
        {
            foreach (GameObject light in yellowTrafficLightsNorthSouth)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;


            }
        }



        if (GreenLightNorthSouth_ON)
        {
            foreach (GameObject light in greenTrafficLightsNorthSouth)
            {
                light.GetComponent<MeshRenderer>().material = greenTrafficLight_ON;


            }
        }
        else
        {
            foreach (GameObject light in greenTrafficLightsNorthSouth)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;


            }
        }
        //====================================================================================

        if (RedLightEastWest_ON)
        {
            foreach (GameObject light in redTrafficLightsEastWest)
            {
                light.GetComponent<MeshRenderer>().material = redTrafficLight_ON;


            }

        }
        else
        {
            foreach (GameObject light in redTrafficLightsEastWest)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;


            }
        }




        if (YellowLightEastWest_ON)
        {
            foreach (GameObject light in yellowTrafficLightsEastWest)
            {
                light.GetComponent<MeshRenderer>().material = yellowTrafficLight_ON;


            }

        }
        else
        {
            foreach (GameObject light in yellowTrafficLightsEastWest)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;


            }
        }



        if (GreenLightEastWest_ON)
        {
            foreach (GameObject light in greenTrafficLightsEastWest)
            {
                light.GetComponent<MeshRenderer>().material = greenTrafficLight_ON;


            }
        }
        else
        {
            foreach (GameObject light in greenTrafficLightsEastWest)
            {
                light.GetComponent<MeshRenderer>().material = trafficLight_OFF;


            }
        }

    }
}
