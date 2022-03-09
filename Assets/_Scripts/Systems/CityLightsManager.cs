using System.Collections.Generic;
using UnityEngine;

public class CityLightsManager : MonoBehaviour
{
    public List<GameObject> CityLights = new List<GameObject>();

    void Start()
    {

    }


    private void Update()
    {
        CheckLights();
    }

    public void CheckLights()
    {
        if (CityLights.Count != 0)
        {
            if (GameData.NightLights)
            {

                foreach (GameObject light in CityLights)
                {
                    light.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject light in CityLights)
                {
                    light.SetActive(false);
                }

            }
        }
        else
        {
            CityLights.AddRange(GameObject.FindGameObjectsWithTag("TAG:StreetLight"));
            if (GameData.NightLights)
            {

                foreach (GameObject light in CityLights)
                {
                    light.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject light in CityLights)
                {
                    light.SetActive(false);
                }

            }
        }


    }
}
