using UnityEngine;

public class Sun_Light : MonoBehaviour
{
    private Light sunLight;
    public float transitionSpeed;
    private float sunLightRotation;
    public float minSunLight;
    public float maxSunLight;


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
            while (GameData.sunLight < maxSunLight)
            {
                GameData.sunLight += transitionSpeed;
            }
        }
        else
        {
            GameData.NightLights = true;
            while (GameData.sunLight > minSunLight)
            {
                GameData.sunLight -= transitionSpeed;
            }
        }
        sunLight.intensity = GameData.sunLight;//Set sunlight to time of day

        //transform.Rotate(sunLightRotation, 0, 0); //not in use
    }
}
