using UnityEngine;

public class Sky_Manager : MonoBehaviour
{
    public Material daySky;
    public Material nightSky;
    public Skybox sky;

    void FixedUpdate()
    {
        UpdateSky();
    }

    public void UpdateSky()
    {
        if (GameData.hour >= 5)//Morning
        {

        }
        else if (GameData.hour >= 11)//Noon
        {

        }
        else if (GameData.hour >= 16)//Evening
        {

        }
        else if (GameData.hour >= 20)//Evening
        {

        }
        else if (GameData.hour >= 23)//Midnight
        {

        }





        if (GameData.NightLights)//if it is daytime,  increment daylight on
        {
            sky.GetComponent<Skybox>().material = nightSky;
        }
        else
        {
            sky.GetComponent<Skybox>().material = daySky;
        }

    }
}