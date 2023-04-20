using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject summaryPanel;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI summaryText;

    private AudioSource menuAudio;
    [SerializeField] AudioClip audioClip;

    private string lackName = "Doggy";
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
        menuAudio = GetComponent<AudioSource>();
        scoreText.text = "Friends fed: " + score;
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
        menuAudio.PlayOneShot(audioClip, 1.0f);
    }

    public void SummaryButton()
    {
        summaryPanel.SetActive(true);
        menuAudio.PlayOneShot(audioClip, 1.0f);
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
        menuAudio.PlayOneShot(audioClip, 1.0f);
    }

    public void BackToMenuButton()
    {
        summaryPanel.SetActive(false);
        menuPanel.SetActive(true);
        menuAudio.PlayOneShot(audioClip, 1.0f);
        SceneManager.LoadScene(0);
    }
}
