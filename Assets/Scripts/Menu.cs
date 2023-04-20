using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject summaryPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI summaryText;

    public string lackName = "Doggy";
    private string playerName;
    public string PlayerName
    {
        get
        {
            if (playerName == null)
            {
                return lackName;
            }
            else
            {
                return playerName;
            }
        }
        set 
        { playerName = value; }
    }
    int score;

    void Start()
    {
        scoreText.text = "Friends fed: " + score;
    }

    void Update()
    {

    }

    public void AddPoint(int point)
    {
        score += point;
        scoreText.text = "Friends fed: " + score;
    }

    public void ReadInput(string name)
    {
        PlayerName = name;
    }

    public void StartGameButton()
    {
        menuPanel.SetActive(false);
    }

    public void SummaryButton()
    {
        summaryPanel.SetActive(true);
        if (score == 1)
        {
            summaryText.text = $"You have fed {score} friend!";
        }
        else
        {
            summaryText.text = $"You have fed {score} friends!";
        }
    }

    public void QuitGameButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ResumeButton()
    {
        summaryPanel.SetActive(false);
    }

    public void BackToMenuButton()
    {
        summaryPanel.SetActive(false);
        menuPanel.SetActive(true);
        SceneManager.LoadScene(0);
    }


}
