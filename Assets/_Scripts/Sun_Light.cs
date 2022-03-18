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
        print("Intensity: " + GameData.sunLight);
        print("NightLight: " + GameData.NightLights);
    }

    private void updateSunLight()
    {
        if (GameData.hour >= 6 && GameData.hour <= 18)//if it is daytime,  increment daylight on
        {
            GameData.NightLights = false;
            if (GameData.sunLight < maxSunLight)
            {
                print("Increase Sunlight");
                GameData.sunLight += transitionSpeed;

            }
        }
        else
        {
            GameData.NightLights = true;
            if (GameData.sunLight > minSunLight)
            {
                print("Decrease Sunlight");
                GameData.sunLight -= transitionSpeed;
            }
        }
        sunLight.intensity = GameData.sunLight;//Set sunlight to time of day
    }
}
