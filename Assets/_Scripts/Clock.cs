using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI pauseText;
    public Button pause;
    public Button play;
    public Button fast;
    public Button faster;

    public int startMonth;
    public int startHour;
    public bool twelveHourClock;

    private void Awake()
    {
        //Set starting day of month to nonzero
        GameData.dayOfMonth = 1;

        //Set Random starting year
        GameData.year = Random.Range(2020, 2050);

        //set starting month of year
        if (startMonth <= 0) { startMonth = 1; }
        GameData.monthOfYear = startMonth - 1;

        //Set Starting hour
        if (startHour != 0)
        {
            GameData.hour = startHour;
        }

        //Reset starting clock default speed
        GameData.timer = GameData.minuteToRealTime;
        updateTimeSpeed("Play");
        updateMeridiem();
        updateTimeDisplay();
    }

    public void Update()
    {
        GameData.timer -= Time.deltaTime;
        if (GameData.timer <= 0)
        {
            updateMinute();//update clock


        }
    }
    private void LateUpdate()
    {
        updateTimeButtons();
    }
    private void updateMinute()
    {
        GameData.min += GameData.gameSpeed;
        GameData.timer = GameData.minuteToRealTime;


        if (GameData.min >= 60)
        {
            GameData.min = 0;
            updateHour();
        }
        updateTimeDisplay();

        GameData.sunTime++;
        if (GameData.sunTime >= 1440)
        {
            GameData.sunTime = 0;

        }
    }

    private void updateHour()
    {
        GameData.hour++;
        updateMeridiem();
        if (GameData.hour >= 24)
        {
            GameData.hour = 0;
            updateDay();
        }
    }

    private void updateMeridiem()
    {
        if (GameData.hour <= 12)
        {
            GameData.ampm = "AM";
        }
        else
        {
            GameData.ampm = "PM";
        }
    }

    private void updateDay()
    {
        GameData.dayOfWeek++;
        GameData.dayOfMonth++;
        if (GameData.dayOfWeek >= 7)
        {
            GameData.dayOfWeek = 1;
            updateWeek();
        }
        if (GameData.dayOfMonth >= GameData.DAYS_IN_MONTH[GameData.monthOfYear])
        {
            GameData.dayOfMonth = 1;
            updateMonth();
        }
    }

    private void updateWeek()
    {
        GameData.numberOfWeeks++;
    }

    private void updateMonth()
    {
        GameData.monthOfYear++;
        ;
        if (GameData.monthOfYear >= 12)
        {
            GameData.monthOfYear = 0;
            updateNewYear();
        }
    }

    private void updateNewYear()
    {
        GameData.year++;
    }

    public void updateTimeDisplay()
    {
        //Update Time Display
        if (twelveHourClock && GameData.hour >= 12)
        {
            timeText.text = $"{(GameData.hour - 12):00}:{GameData.min:00} {GameData.ampm}";
            dateText.text = $"{GameData.DAYS_IN_WEEK[GameData.dayOfWeek]} {GameData.MONTHS_IN_YEAR[GameData.monthOfYear]} {GameData.dayOfMonth}, {GameData.year}";
        }
        else
        {
            timeText.text = $"{GameData.hour:00}:{GameData.min:00} {GameData.ampm}";
            dateText.text = $"{GameData.DAYS_IN_WEEK[GameData.dayOfWeek]} {GameData.MONTHS_IN_YEAR[GameData.monthOfYear]} {GameData.dayOfMonth}, {GameData.year}";
        }
    }

    public void updateTimeSpeed(string ts)
    {
        switch (ts)
        {
            case "Faster":
                GameData.gameSpeed = 20;
                break;
            case "Fast":
                GameData.gameSpeed = 10;
                break;
            case "Play":
                GameData.gameSpeed = 1;
                break;
            case "Pause":
                GameData.gameSpeed = 0;
                break;
            default:
                GameData.gameSpeed = 1;
                break;
        }
        updateTimeButtons();
    }

    void updateTimeButtons()
    {
        float ts = GameData.gameSpeed;
        if (ts <= 0) { pauseText.gameObject.SetActive(true); }
        else { pauseText.gameObject.SetActive(false); }
        switch (ts)
        {
            case 20:
                faster.Select();
                break;
            case 10:
                fast.Select();
                break;
            case 1:
                play.Select();
                break;
            case 0:
                pause.Select();
                break;
            default:
                play.Select();
                break;
        }
    }
}



