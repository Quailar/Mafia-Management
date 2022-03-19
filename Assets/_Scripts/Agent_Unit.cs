using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class Agent_Unit : MonoBehaviour
{
    public GameData gameData;
    public NavMeshAgent navmeshAgent;
    public List<Outline> mOutlineBody = new List<Outline>();
    public List<Outline> fOutlineBody = new List<Outline>();
    public List<Outline> mOutlineHead = new List<Outline>();
    public List<Outline> fOutlineHead = new List<Outline>();
    public List<Agent_Unit_SO> AGENT_UNIT_SO_LIST = new List<Agent_Unit_SO>();
    public Agent_Unit_SO unitSO;
    public Animator animator;
    public Avatar[] avatar;
    public int Body;
    public int Head;
    public GameObject[] mBodys;
    public GameObject[] mHeads;
    public GameObject[] mWeapons;
    public GameObject[] mItems;
    public GameObject[] fBodys;
    public GameObject[] fHeads;
    public GameObject[] fWeapons;
    public GameObject[] fItems;


    public void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();

        GetProfile();

    }
    private void FixedUpdate()
    {
        navmeshAgent.speed = 1 * GameData.gameSpeed;
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

        if (unitSO.Gender == "Male")
        {
            mOutlineBody[unitSO.Body].enabled = true;
            mOutlineHead[unitSO.Head].enabled = true;
        }
        else
        {
            fOutlineBody[unitSO.Body].enabled = true;
            fOutlineHead[unitSO.Head].enabled = true;
        }
        Debug.Log(unitSO.FirstName + " " + unitSO.LastName);

    }
    private void OnMouseExit()
    {
        if (unitSO.Gender == "Male")
        {
            mOutlineBody[unitSO.Body].enabled = false;
            mOutlineHead[unitSO.Head].enabled = false;
        }
        else
        {
            fOutlineBody[unitSO.Body].enabled = false;
            fOutlineHead[unitSO.Head].enabled = false;
        }
    }

    private void OnMouseUp()
    {
        unitSO.isSelected = true;
        Debug.Log(unitSO.isSelected);
    }


}
