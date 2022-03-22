using System.Collections.Generic;
using UnityEngine;

public class CityLightsManager : MonoBehaviour
{
    public List<GameObject> CityLamps = new List<GameObject>();
    public List<GameObject> CityLights = new List<GameObject>();

    private void Start()
    {
        CityLamps.AddRange(GameObject.FindGameObjectsWithTag("StreetLight:Lamp"));
        CityLights.AddRange(GameObject.FindGameObjectsWithTag("StreetLight:PointLight"));
    }
    private void Update()
    {

        CheckLights();
    }

    public void CheckLights()
    {
        if (GameData.hour < 6 || GameData.hour > 16)
        {
            GameData.NightLights = true;
        }
        else
        {
            GameData.NightLights = false;
        }
        if (CityLights.Count != 0)
        {


            if (GameData.NightLights)
            {

                foreach (GameObject light in CityLamps)
                {
                    light.SetActive(true);
                }
                foreach (GameObject light in CityLights)
                {
                    light.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject light in CityLamps)
                {
                    light.SetActive(false);
                }
                foreach (GameObject light in CityLights)
                {
                    light.SetActive(false);
                }

            }
        }


    }
}
