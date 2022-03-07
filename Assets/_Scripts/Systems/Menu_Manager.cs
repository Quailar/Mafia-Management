using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Manager : MonoBehaviour
{
    public void TitleMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TitleOptions()
    {
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    public void SetMapSize(string size)
    {
        GameData.MapSize = size;
        SetMaxAgents(GameData.MapSize);
    }

    public void SetMaxPlayers(int max)
    {
        GameData.MaxPlayers = max;
    }

    public void SetMaxAgents(string size)
    {
        switch (size)
        {
            case "Large":
                GameData.MaxCivilians = 250;
                GameData.MaxAutos = 125;
                break;
            case "Medium":
                GameData.MaxCivilians = 150;
                GameData.MaxAutos = 75;
                break;
            case "Small":
                GameData.MaxCivilians = 100;
                GameData.MaxAutos = 50;
                break;
            default:
                GameData.MaxCivilians = 100;
                GameData.MaxAutos = 50;
                break;
        }
    }
}
