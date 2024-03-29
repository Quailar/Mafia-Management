using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int trafficTimerNorthSouth;
    public int trafficTimerEastWest;
    public bool dirSwitch = false;

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
    public List<GameObject> streetLampPointLight;
    public List<GameObject> streetLampSpotLight;

    private void Start()
    {
        trafficPolesNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:NorthSouth"));
        trafficPolesEastWest.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:EastWest"));

        redTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:RedLampNorthSouth"));
        greenTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:GreenLampNorthSouth"));
        yellowTrafficLightsNorthSouth.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:YellowLampNorthSouth"));

        redTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:RedLampEastWest"));
        greenTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:GreenLampEastWest"));
        yellowTrafficLightsEastWest.AddRange(GameObject.FindGameObjectsWithTag("TrafficLight:YellowLampEastWest"));

        streetLamps.AddRange(GameObject.FindGameObjectsWithTag("StreetLight:Lamp"));
        streetLampPointLight.AddRange(GameObject.FindGameObjectsWithTag("StreetLight:PointLight"));
        streetLampSpotLight.AddRange(GameObject.FindGameObjectsWithTag("StreetLight:SpotLight"));
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        LightTimer(dirSwitch);
    }

    public void LightTimer(bool signal)
    {
        if (dirSwitch)
        {
            trafficTimerNorthSouth++;
            if (trafficTimerNorthSouth < GreenLightTimer)
            {
                GreenLightNorthSouth_ON = true;
                YellowLightNorthSouth_ON = false;
                RedLightNorthSouth_ON = false;
            }
            else if (trafficTimerNorthSouth < YellowLightTimer)
            {
                GreenLightNorthSouth_ON = false;
                YellowLightNorthSouth_ON = true;
                RedLightNorthSouth_ON = false;
            }
            else if (trafficTimerNorthSouth >= RedLightTimer)
            {
                GreenLightNorthSouth_ON = false;
                YellowLightNorthSouth_ON = false;
                RedLightNorthSouth_ON = true;
                dirSwitch = false;
                trafficTimerNorthSouth = 0;
            }
        }
        else
        {
            trafficTimerEastWest++;
            if (trafficTimerEastWest < GreenLightTimer)
            {
                GreenLightEastWest_ON = true;
                YellowLightEastWest_ON = false;
                RedLightEastWest_ON = false;
            }
            else if (trafficTimerEastWest < YellowLightTimer)
            {
                GreenLightEastWest_ON = false;
                YellowLightEastWest_ON = true;
                RedLightEastWest_ON = false;
            }
            else if (trafficTimerEastWest >= RedLightTimer)
            {
                GreenLightEastWest_ON = false;
                YellowLightEastWest_ON = false;
                RedLightEastWest_ON = true;
                dirSwitch = true;
                trafficTimerEastWest = 0;
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

