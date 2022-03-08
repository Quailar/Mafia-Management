using UnityEngine;

public class Sun_Light : MonoBehaviour
{
    private Light sunLight;
    private float sunLightRotation;

    // Start is called before the first frame update
    void Start()
    {
        sunLight = GameObject.FindGameObjectWithTag("SunLight").GetComponent<Light>();
    }

    // Update is called once per frame
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
        if (GameData.hour > 6)
            sunLightRotation = 35;
        if (GameData.hour > 12)
            sunLightRotation = 90;
        if (GameData.hour > 15)
            sunLightRotation = 125;
        if (sunLightRotation < 0)
            sunLightRotation += 360;

        //transform.Rotate(sunLightRotation, 0, 0);
    }
}
