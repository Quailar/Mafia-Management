using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Tuen on the auto navigation path.  primariry for debugging
public class Agent_Counter : MonoBehaviour
{

    public TextMeshProUGUI civCount;
    public TextMeshProUGUI autoCount;

    private void FixedUpdate()
    {
        civCount.text = GameData.TotalCivilians.ToString();
        autoCount.text = GameData.TotalAutos.ToString();
    }


}
