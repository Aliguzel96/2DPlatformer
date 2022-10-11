using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;


    private void Start()
    {
        scoreText = GameObject.Find("ScoreValue").GetComponent<TextMeshProUGUI>();
        Load();
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Save();
        Load();
       
    }

    public void Restart()
    {
        Time.timeScale = 1;//oyun bitince zaman duruyordu restart deyince yeniden baþlamasý gerekiyor
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ClosePanel(string parentName)
    {
        Time.timeScale = 0;
        GameObject.Find(parentName).SetActive(false);
    }

    public void AddScore(int score)
    {
        int scoreValue = int.Parse(scoreText.text);
        scoreValue += score;
        scoreText.text = scoreValue.ToString();
    }

    public void Load()
    {
        SaveSystem.LoadPlayer();
        scoreText.text = Data.score.ToString();
    }

    public void Save()
    {
        Data.score = int.Parse(scoreText.text);
        SaveSystem.SavePlayer();
    }
}
