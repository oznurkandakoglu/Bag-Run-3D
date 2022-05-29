using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    //[SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject tapToStartPanel;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private TextMeshProUGUI textLevel2;

   

    public static bool gameOver;
    public static bool nextScene;

    public static UIManager instance;

    //private List<int> scenarios;

    //private UIManager()
    //{
    //    scenarios = new List<int> { 1, 2, 3 };
    //}

    //public static UIManager Instance
    //{
    //    get => instance == null ? (instance = new UIManager()) : instance;
    //}

    //public void LoadNextScene()
    //{
    //    if (scenarios.Count == 0)
    //        return;
    //    PlayerDatas.LevelIndex = UnityEngine.Random.Range(0, scenarios.Count);
    //    int currenScenario = scenarios[PlayerDatas.LevelIndex];
    //    scenarios.RemoveAt(PlayerDatas.LevelIndex);
    //    SceneManager.LoadScene(currenScenario);
    //    //PlayerDatas.LevelIndex = UnityEngine.Random.Range(0, 4);
    //    //SceneManager.LoadScene(PlayerDatas.LevelIndex);
    //}

    public void Start()
    {
        nextScene = false;
        gameOverPanel.SetActive(false);
        //nextLevelPanel.SetActive(false);
        gameOver = false;
        tapToStartPanel.SetActive(true);
        textLevel.text = "Level" + " " + PlayerDatas.countLevel.ToString();
        Time.timeScale = 0;
    }

    public void TapToStart()
    {
        Time.timeScale = 1;
        tapToStartPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverPanel.SetActive(false);
    }

    //public void NextLevel()
    //{
    //    PlayerDatas.countLevel++;
    //    LoadNextScene();
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        if (nextScene)
        {
            gamePanel.SetActive(false);
            //nextLevelPanel.SetActive(true);
        }

        
        textLevel2.text = PlayerDatas.point.ToString();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}