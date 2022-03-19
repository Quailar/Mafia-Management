using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class Manager_Unit : MonoBehaviour
{
    public GameData gameData;
    public NavMeshAgent navmeshAgent;
    public List<Manager_Unit_SO> MANAGER_UNIT_SO_LIST = new List<Manager_Unit_SO>();
    public Manager_Unit_SO managerSO;
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
        int randomSO = Random.Range(0, MANAGER_UNIT_SO_LIST.Count);
        managerSO = MANAGER_UNIT_SO_LIST[randomSO];
        MANAGER_UNIT_SO_LIST.Remove(MANAGER_UNIT_SO_LIST[randomSO]);
        managerSO.ID = GetInstanceID();

        int g = Random.Range(0, 2);
        if (g == 0)
        {
            managerSO.Gender = "Male";
            int mn = Random.Range(0, GameData.MALE_FIRST_NAMES.Length);
            managerSO.FirstName = GameData.MALE_FIRST_NAMES[mn];
            int nn = Random.Range(0, GameData.MALE_NICK_NAMES.Length);
            managerSO.NickName = GameData.MALE_NICK_NAMES[nn];
            managerSO.Body = Random.Range(0, mBodys.Length);
            managerSO.Head = Random.Range(0, mHeads.Length);
            animator.avatar = avatar[0];
            mBodys[managerSO.Body].SetActive(true);
            mHeads[managerSO.Head].SetActive(true);
        }
        else
        {
            managerSO.Gender = "Female";
            int fn = Random.Range(0, GameData.FEMALE_FIRST_NAMES.Length);
            managerSO.FirstName = GameData.FEMALE_FIRST_NAMES[fn];
            int nn = Random.Range(0, GameData.FEMALE_NICK_NAMES.Length);
            managerSO.NickName = GameData.FEMALE_NICK_NAMES[nn];
            managerSO.Body = Random.Range(0, fBodys.Length);
            managerSO.Head = Random.Range(0, fHeads.Length);
            animator.avatar = avatar[1];
            fBodys[managerSO.Body].SetActive(true);
            fHeads[managerSO.Head].SetActive(true);
            fHeads[managerSO.Head].SetActive(true);
        }

        int ln = Random.Range(0, GameData.LAST_NAMES.Length);
        managerSO.LastName = GameData.LAST_NAMES[ln];

        managerSO.Speed = (managerSO.Speed / 10) + 1;
    }

    private void OnMouseOver()
    {
        Debug.Log(managerSO.FirstName + " " + managerSO.LastName);
    }

    private void OnMouseUp()
    {
        managerSO.isSelected = true;
        Debug.Log(managerSO.isSelected);
    }
}