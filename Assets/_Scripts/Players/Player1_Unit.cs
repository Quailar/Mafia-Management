using UnityEngine;
using System.Collections.Generic;
public class Player1_Unit : MonoBehaviour
{
    public Player1_SO unitSO;

    public GameObject[] mWeapons;
    public GameObject[] mItems;

    public GameObject[] fWeapons;
    public GameObject[] fItems;


    private void Update()
    {
        CheckLights();
    }

    private void OnMouseOver()
    {
        Debug.Log(unitSO.FirstName);
    }

    private void OnMouseUp()
    {
        unitSO.isSelected = true;
        Debug.Log(unitSO.isSelected);
    }
    public void CheckLights()
    {
        if (GameData.NightLights && unitSO.Gender == "Female")
        {
            fItems[0].SetActive(true);
        }
        else if (GameData.NightLights && unitSO.Gender == "Male")
        {
            mItems[0].SetActive(true);
        }
        else
        {
            mItems[0].SetActive(false);
            fItems[0].SetActive(false);
        }
    }

    public void GetName(string firstName, string lastName)
    {
        string fullname = $"({firstName} + {lastName})";
        return;
    }
}
