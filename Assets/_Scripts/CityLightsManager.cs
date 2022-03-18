using System.Collections.Generic;
using UnityEngine;

public class CityLightsManager : MonoBehaviour
{
    public List<GameObject> CityLights = new List<GameObject>();

    private void Update()
    {
        CheckLights();
    }

    public void CheckLights()
    {
        if (CityLights.Count != 0)
        {

            CityLights.AddRange(GameObject.FindGameObjectsWithTag("StreetLight:Lamp"));
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
