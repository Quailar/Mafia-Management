using UnityEngine;

public class Sun_Light : MonoBehaviour
{
    private Light sunLight;
    private float sunLightRotation;


    void Start()
    {
        sunLight = GameObject.FindGameObjectWithTag("SunLight").GetComponent<Light>();
    }


    void FixedUpdate()
    {
        updateSunLight();
    }

    private void updateSunLight()
    {
        if (GameData.hour >= 6 && GameData.hour <= 18)//if it is daytime,  increment daylight on
        {
            GameData.NightLights = false;
            while (GameData.sunLight < 1)
            {
                GameData.sunLight += .001f;
            }
        }
        else
        {
            GameData.NightLights = true;
            while (GameData.sunLight > 0)
            {
                GameData.sunLight -= .001f;
            }
        }
        sunLight.intensity = GameData.sunLight;//Set sunlight to time of day

        //transform.Rotate(sunLightRotation, 0, 0); //not in use
    }
}
