using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreationManager : MonoBehaviour
{
    public Player1_SO Player1_SO;
    public Animator animator;
    public Avatar[] avatar;
    public GameObject agentPrefab;
    public Button maleButton;
    public Button femaleButton;

    public List<Button> HeadIncreaseButton = new List<Button>();
    public List<Button> bodyIncreaseButton = new List<Button>();
    public List<Button> HeadDecreaseButton = new List<Button>();
    public List<Button> bodyDecreaseButton = new List<Button>();
    public List<GameObject> maleHeads = new List<GameObject>();
    public List<GameObject> maleBodys = new List<GameObject>();
    public List<GameObject> femaleHeads = new List<GameObject>();
    public List<GameObject> femaleBodys = new List<GameObject>();

    public int rotSensitivity;
    public bool isMale;
    public int maleHeadID;
    public int maleBodyID;
    public int femaleHeadID;
    public int femaleBodyID;


    public TextMeshProUGUI textHeadID;
    public TextMeshProUGUI textBodyID;
    public TextMeshProUGUI textFirstName;
    public TextMeshProUGUI textLastName;
    public TextMeshProUGUI textNickName;
    public TextMeshProUGUI textMaxHitPoints;
    public TextMeshProUGUI textStrength;
    public TextMeshProUGUI textIntelligence;
    public TextMeshProUGUI textSpeed;
    public TextMeshProUGUI textStamina;
    public TextMeshProUGUI textDriving;
    public TextMeshProUGUI textUnarmed;
    public TextMeshProUGUI textFireArms;
    public TextMeshProUGUI textExplosives;
    public TextMeshProUGUI textDodge;
    public TextMeshProUGUI textStealth;
    public TextMeshProUGUI textCharisma;
    public TextMeshProUGUI textCostToHire;
    public TextMeshProUGUI textPricePerMonth;

    void Start()
    {
        Player1_SO.TeamName = "Player1";//Set player1 team
        RandomizeAll();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float _input_hor = Input.GetAxis("Mouse X");//get mouse x axis
            if (_input_hor != 0)//if mouse is moving on the x axis
            {
                agentPrefab.transform.Rotate(Vector3.up * -_input_hor * rotSensitivity);//rotate character model on x axis if mouse is moving
            }
        }
    }

    private void LateUpdate()
    {
        UpdateDisplay();
        UpdateButtons();
    }

    public void ConfirmChoice()
    {
        SceneManager.LoadScene(3);

    }


    //-----------------------------------------
    //------------CHANGE CHARCTER--------------
    //-----------------------------------------
    public void IncreaseHead()//increase head array index
    {

        if (isMale)
        {
            maleHeads[maleHeadID].SetActive(false);
            maleHeadID++;
            if (maleHeadID > maleHeads.Count - 1)
            {
                maleHeadID = 0;
            }
            maleHeads[maleHeadID].SetActive(true);
        }
        else
        {
            femaleHeads[femaleHeadID].SetActive(false);
            femaleHeadID++;
            if (femaleHeadID > femaleHeads.Count - 1)
            {
                femaleHeadID = 0;
            }
            femaleHeads[femaleHeadID].SetActive(true);
        }
    }

    public void DecreaseHead()
    {
        if (isMale)
        {
            maleHeads[maleHeadID].SetActive(false);
            maleHeadID--;
            if (maleHeadID < 0)
            {
                maleHeadID = maleHeads.Count - 1;
            }
            maleHeads[maleHeadID].SetActive(true);
        }
        else
        {
            femaleHeads[femaleHeadID].SetActive(false);
            femaleHeadID--;
            if (femaleHeadID < 0)
            {
                femaleHeadID = femaleHeads.Count - 1;
            }
            femaleHeads[femaleHeadID].SetActive(true);
        }
    }

    public void IncreaseBody()
    {
        if (isMale)
        {
            maleBodys[maleBodyID].SetActive(false);
            maleBodyID++;
            if (maleBodyID > maleBodys.Count - 1)
            {
                maleBodyID = 0;
            }
            maleBodys[maleBodyID].SetActive(true);
        }
        else
        {
            femaleBodys[femaleBodyID].SetActive(false);
            femaleBodyID++;
            if (femaleBodyID > femaleBodys.Count - 1)
            {
                femaleBodyID = 0;
            }
            femaleBodys[femaleBodyID].SetActive(true);
        }
    }

    public void DecreaseBody()
    {
        if (isMale)
        {
            maleBodys[maleBodyID].SetActive(false);
            maleBodyID--;
            if (maleBodyID < 0)
            {
                maleBodyID = maleBodys.Count - 1;
            }
            maleBodys[maleBodyID].SetActive(true);
        }
        else
        {
            femaleBodys[femaleBodyID].SetActive(false);
            femaleBodyID--;
            if (femaleBodyID < 0)
            {
                femaleBodyID = femaleBodys.Count - 1;
            }
            femaleBodys[femaleBodyID].SetActive(true);
        }
    }





    //-----------------------------------------
    //---------------RANDOMIZE-----------------
    //-----------------------------------------

    public void RandomizeAll()
    {
        RandomizeCharacter();
        RandomizeStats();
    }

    public void RandomizeCharacter()
    {
        ClearCharacter();

        int g = Random.Range(0, 2);
        if (g == 0)
        {
            isMale = true;
            maleHeadID = Random.Range(0, maleHeads.Count);
            maleBodyID = Random.Range(0, maleBodys.Count);

            maleHeads[maleHeadID].SetActive(true);
            maleBodys[maleBodyID].SetActive(true);
        }
        else
        {
            isMale = false;
            femaleHeadID = Random.Range(0, femaleHeads.Count);
            femaleBodyID = Random.Range(0, femaleBodys.Count);

            femaleHeads[femaleHeadID].SetActive(true);
            femaleBodys[femaleBodyID].SetActive(true);
        }
        ChangeGender(isMale);
    }

    public void RandomizeStats()
    {
        if (isMale)
        {
            int mfn = Random.Range(0, GameData.MALE_FIRST_NAMES.Length);
            Player1_SO.FirstName = GameData.MALE_FIRST_NAMES[mfn];

            int nn = Random.Range(0, GameData.MALE_NICK_NAMES.Length);
            Player1_SO.NickName = GameData.MALE_NICK_NAMES[nn];
        }
        else
        {
            int ffn = Random.Range(0, GameData.FEMALE_FIRST_NAMES.Length);
            Player1_SO.FirstName = GameData.FEMALE_FIRST_NAMES[ffn];
            int nn = Random.Range(0, GameData.FEMALE_NICK_NAMES.Length);
            Player1_SO.NickName = GameData.FEMALE_NICK_NAMES[nn];
        }

        int ln = Random.Range(0, GameData.LAST_NAMES.Length);
        Player1_SO.LastName = GameData.LAST_NAMES[ln];



        Player1_SO.MaxHitPoints = Random.Range(80, 120);
        Player1_SO.CurrentHitPoints = Player1_SO.MaxHitPoints;
        Player1_SO.Strength = Random.Range(1, 10);
        Player1_SO.Intelligence = Random.Range(1, 10);
        Player1_SO.Speed = Random.Range(1, 10);
        Player1_SO.Stamina = Random.Range(1, 10);
        Player1_SO.Driving = Random.Range(1, 10);
        Player1_SO.Unarmed = Random.Range(1, 10);
        Player1_SO.FireArms = Random.Range(1, 10);
        Player1_SO.Explosives = Random.Range(1, 10);
        Player1_SO.Dodge = Random.Range(1, 10);
        Player1_SO.Stealth = Random.Range(1, 10);
        Player1_SO.Charisma = Random.Range(1, 10);
        Player1_SO.TotalStats = Player1_SO.MaxHitPoints + Player1_SO.Strength + Player1_SO.Intelligence + Player1_SO.Speed + Player1_SO.Driving + Player1_SO.Unarmed + Player1_SO.FireArms + Player1_SO.Explosives + Player1_SO.Dodge + Player1_SO.Stealth + Player1_SO.Charisma;
        Player1_SO.CostToHire = Player1_SO.TotalStats * Player1_SO.Speed;
        Player1_SO.PricePerMonth = Player1_SO.TotalStats;
    }






    //-----------------------------------------
    //-------------CHANGE GENDER---------------
    //-----------------------------------------

    public void ChangeGender(bool g)
    {
        ClearCharacter();
        if (g)
        {
            isMale = true;
            maleHeads[maleHeadID].SetActive(true);
            maleBodys[maleBodyID].SetActive(true);
            animator.avatar = avatar[0];
        }
        else
        {
            isMale = false;
            femaleHeads[femaleHeadID].SetActive(true);
            femaleBodys[femaleBodyID].SetActive(true);
            animator.avatar = avatar[1];
        }

    }







    //-----------------------------------------
    //-------------CLEAR CHARACTER-------------
    //-----------------------------------------
    private void ClearCharacter()
    {
        foreach (GameObject obj in femaleHeads)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in femaleBodys)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in maleHeads)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in maleBodys)
        {
            obj.SetActive(false);
        }
    }









    //-----------------------------------------
    //-------------DISPLAY---------------------
    //-----------------------------------------
    //Updates text values and buttons on screen

    public void UpdateButtons()
    {
        if (isMale)
        {
            maleButton.Select();//if male model highlight male button

        }
        else
        {
            femaleButton.Select();//if model is female highlight female button
        }
    }

    public void UpdateDisplay()
    {
        if (isMale)
        {
            textHeadID.text = maleHeadID.ToString();
            textBodyID.text = maleBodyID.ToString();
        }
        else
        {
            textHeadID.text = femaleHeadID.ToString();
            textBodyID.text = femaleBodyID.ToString();
        }
        textFirstName.text = Player1_SO.FirstName.ToString();
        textLastName.text = Player1_SO.LastName.ToString();




        textNickName.text = Player1_SO.NickName.ToString();
        textMaxHitPoints.text = Player1_SO.MaxHitPoints.ToString();
        textStrength.text = Player1_SO.Strength.ToString();
        textIntelligence.text = Player1_SO.Intelligence.ToString();
        textSpeed.text = Player1_SO.Speed.ToString();
        textStamina.text = Player1_SO.Stamina.ToString();
        textDriving.text = Player1_SO.Driving.ToString();
        textUnarmed.text = Player1_SO.Unarmed.ToString();
        textFireArms.text = Player1_SO.FireArms.ToString();
        textExplosives.text = Player1_SO.Explosives.ToString();
        textDodge.text = Player1_SO.Dodge.ToString();
        textStealth.text = Player1_SO.Stealth.ToString();
        textCharisma.text = Player1_SO.Charisma.ToString();
        textCostToHire.text = Player1_SO.CostToHire.ToString();
        textPricePerMonth.text = Player1_SO.PricePerMonth.ToString();
    }
}
