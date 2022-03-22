using UnityEngine;

public class Sky_Manager : MonoBehaviour
{
    public Skybox sky;
    public Material morningSky;
    public Material noonSky;
    public Material sunsetSky;
    public Material nightSky;



    void FixedUpdate()
    {
        UpdateSky();
    }

    public void UpdateSky()
    {
        if (GameData.hour < 6 || GameData.hour > 20)//Night
        {
            sky.GetComponent<Skybox>().material = nightSky;
        }

        if (GameData.hour >= 6)//Morning
        {
            sky.GetComponent<Skybox>().material = morningSky;
        }

        else if (GameData.hour >= 11)//Noon
        {
            sky.GetComponent<Skybox>().material = noonSky;
        }

        else if (GameData.hour >= 13)//Evening
        {
            sky.GetComponent<Skybox>().material = sunsetSky;
        }

    }
}