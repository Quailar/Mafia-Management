using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TrafficLightController : MonoBehaviour
{

    public List<GameObject> trafficPolesNorthSouth;
    public List<GameObject> trafficPolesEastWest;
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

    public int GreenLightTimer;
    public int YellowLightTimer;
    public int RedLightTimer;

    public bool RedLightNorthSouth_ON;
    public bool YellowLightNorthSouth_ON;
    public bool GreenLightNorthSouth_ON;
    public bool RedLightEastWest_ON;
    public bool YellowLightEastWest_ON;
    public bool GreenLightEastWest_ON;

    public List<GameObject> streetLamps;
    public List<GameObject> streetLampBulb;
    public List<GameObject> streetLampPointLight;
    public List<GameObject> streetLampSpotLight;

    private void Awake()
    {
        trafficPolesNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TrafficLightNorthSouth"));
        trafficPolesEastWest.AddRange(GameObject.FindGameObjectsWithTag("TrafficLightEastWest"));


        redTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TAG:RedLightLampNorthSouth"));
        greenTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TAG:GreenLightLampNorthSouth"));
        yellowTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TAG:YellowLightLampNorthSouth"));

        redTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TAG:RedLightLampEastWest"));
        greenTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TAG:GreenLightLampEastWest"));
        yellowTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TAG:YellowLightLampEastWest"));

        streetLamps.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLampPole"));
        streetLampBulb.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLamp"));
        streetLampPointLight.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLampPointLight"));
        streetLampSpotLight.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLampSpotLight"));
    }



    // Update is called once per frame
    public void LateUpdate()
    {
        Timer(dirSwitch);
    }
    public void Timer(int signal)
    {
        if (dirSwitch == 0)
        {
            trafficSignalNorthSouth++;
            if (trafficSignalNorthSouth < GreenLightTimer)
            {
                GreenLightNorthSouth_ON = true;
                YellowLightNorthSouth_ON = false;
                RedLightNorthSouth_ON = false;
            }
            else if (trafficSignalNorthSouth < YellowLightTimer)
            {
                GreenLightNorthSouth_ON = false;
                YellowLightNorthSouth_ON = true;
                RedLightNorthSouth_ON = false;
            }
            else if (trafficSignalNorthSouth >= RedLightTimer)
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
            if (trafficSignalEastWest < GreenLightTimer)
            {
                GreenLightEastWest_ON = true;
                YellowLightEastWest_ON = false;
                RedLightEastWest_ON = false;
            }
            else if (trafficSignalEastWest < YellowLightTimer)
            {
                GreenLightEastWest_ON = false;
                YellowLightEastWest_ON = true;
                RedLightEastWest_ON = false;
            }
            else if (trafficSignalEastWest >= RedLightTimer)
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



    public void CheckLight()
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

