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

    }

    private void OnMouseOver()
    {
        Debug.Log(unitSO.FirstName + " " + unitSO.LastName);
    }

    private void OnMouseUp()
    {
        unitSO.isSelected = true;
        Debug.Log(unitSO.isSelected);
    }

    public void GetName(string firstName, string lastName)
    {
        string fullname = $"({firstName} + {lastName})";
        return;
    }
}
