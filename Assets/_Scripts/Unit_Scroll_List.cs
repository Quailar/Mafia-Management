using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Unit_Scroll_List : MonoBehaviour
{
    public ScrollRect myScrollRect;
    public RectTransform scrollableContent;
    public Button button;
    public GameObject buttonInstanceFolder;
    public static List<GameObject> TotalButtons = new List<GameObject>();
    public int counter = 0;
    public string AgentSO;



    private void LateUpdate()
    {
        if (counter != GameData.LIST_ALL_AGENTS.Count)
        {
            counter = GameData.LIST_ALL_AGENTS.Count;
            RefreshList();
        }
    }

    private void RefreshList()
    {
        foreach (GameObject unit in GameData.LIST_ALL_AGENTS)
        {
            if (!TotalButtons.Contains(unit))
            {
                AgentSO = unit.GetComponent<Agent_Unit>().unitSO.FirstName + " " + unit.GetComponent<Agent_Unit>().unitSO.LastName;

                Button spawnButton = Instantiate(button, Vector2.zero, Quaternion.identity);
                spawnButton.transform.parent = buttonInstanceFolder.transform;

                spawnButton.GetComponentInChildren<TextMeshProUGUI>().text = AgentSO;
                TotalButtons.Add(unit);
            }
        }
        // assigns the content that can be scrolled using the ScrollRect.
        myScrollRect.content = scrollableContent;
    }
}

