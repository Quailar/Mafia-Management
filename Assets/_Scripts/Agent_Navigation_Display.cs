
using UnityEngine;



//Tuen on the auto navigation path.  primariry for debugging
public class Agent_Navigation_Display : MonoBehaviour
{

    public void DisplayPath()
    {
        if (GameData.agentDisplayPath == false)
        {
            GameData.agentDisplayPath = true;
        }
        else
        {
            GameData.agentDisplayPath = false;
        }

    }
}
