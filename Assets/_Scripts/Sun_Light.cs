using UnityEngine;

public class Sun_Light : MonoBehaviour
{
    public Light sunLight;
    public float transitionSpeed;
    public float minSunLight;
    public float maxSunLight;

    void Awake()
    {
        GameData.sunLight = sunLight.intensity;
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
            if (GameData.sunLight < maxSunLight)
            {

                GameData.sunLight += transitionSpeed;

            }
        }
        else
        {
            GameData.NightLights = true;
            if (GameData.sunLight > minSunLight)
            {

                GameData.sunLight -= transitionSpeed;
            }
        }
        sunLight.intensity = GameData.sunLight;//Set sunlight to time of day
    }
}
