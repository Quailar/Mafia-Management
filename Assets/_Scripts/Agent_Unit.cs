using UnityEngine;
using System.Collections.Generic;
public class Agent_Unit : MonoBehaviour
{
    public GameData gameData;
    public List<Agent_Unit_SO> AGENT_UNIT_SO_LIST = new List<Agent_Unit_SO>();
    public Agent_Unit_SO unitSO;
    public Animator animator;
    public Avatar[] avatar;
    public GameObject[] mBodys;
    public GameObject[] mHeads;
    public GameObject[] mWeapons;
    public GameObject[] mItems;
    public GameObject[] fBodys;
    public GameObject[] fHeads;
    public GameObject[] fWeapons;
    public GameObject[] fItems;


    public void Awake()
    {
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();

        GetProfile();

    }
    private void FixedUpdate()
    {
        //CheckLights();
    }



    public void GetProfile()
    {
        int randomSO = Random.Range(0, AGENT_UNIT_SO_LIST.Count);
        unitSO = AGENT_UNIT_SO_LIST[randomSO];
        AGENT_UNIT_SO_LIST.Remove(AGENT_UNIT_SO_LIST[randomSO]);
        unitSO.ID = GetInstanceID();

        int g = Random.Range(0, 2);
        if (g == 0)
        {
            unitSO.Gender = "Male";
            int mn = Random.Range(0, GameData.MALE_FIRST_NAMES.Length);
            unitSO.FirstName = GameData.MALE_FIRST_NAMES[mn];
            int nn = Random.Range(0, GameData.MALE_NICK_NAMES.Length);
            unitSO.NickName = GameData.MALE_NICK_NAMES[nn];
            unitSO.Body = Random.Range(0, mBodys.Length);
            unitSO.Head = Random.Range(0, mHeads.Length);
            animator.avatar = avatar[0];
            mBodys[unitSO.Body].SetActive(true);
            mHeads[unitSO.Head].SetActive(true);
        }
        else
        {
            unitSO.Gender = "Female";
            int fn = Random.Range(0, GameData.FEMALE_FIRST_NAMES.Length);
            unitSO.FirstName = GameData.FEMALE_FIRST_NAMES[fn];
            int nn = Random.Range(0, GameData.FEMALE_NICK_NAMES.Length);
            unitSO.NickName = GameData.FEMALE_NICK_NAMES[nn];
            unitSO.Body = Random.Range(0, fBodys.Length);
            unitSO.Head = Random.Range(0, fHeads.Length);
            animator.avatar = avatar[1];
            fBodys[unitSO.Body].SetActive(true);
            fHeads[unitSO.Head].SetActive(true);
            fHeads[unitSO.Head].SetActive(true);
        }

        int ln = Random.Range(0, GameData.LAST_NAMES.Length);
        unitSO.LastName = GameData.LAST_NAMES[ln];

        unitSO.Speed = (unitSO.Speed / 10) + 1;
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

}
