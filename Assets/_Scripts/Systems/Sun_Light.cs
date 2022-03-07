using UnityEngine;

public class Sun_Light : MonoBehaviour
{
    private Light sunLight;

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
    }
}
