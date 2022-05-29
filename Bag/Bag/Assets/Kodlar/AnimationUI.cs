using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AnimationUI : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelPanel;

    public static AnimationUI instance;


    public static bool nextScene;

    private List<int> scenarios;

    private AnimationUI()
    {
        scenarios = new List<int> { 1, 2, 3, 4, 5, 6};
    }

    public static AnimationUI Instance
    {
        get => instance == null ? (instance = new AnimationUI()) : instance;
    }


    public void LoadNextScene()
    {
        if (scenarios.Count == 0)
            return;
        PlayerDatas.LevelIndex = UnityEngine.Random.Range(0, scenarios.Count);
        int currenScenario = scenarios[PlayerDatas.LevelIndex];
        scenarios.RemoveAt(PlayerDatas.LevelIndex);
        SceneManager.LoadScene(currenScenario);
    }

    public void NextLevel()
    {
        PlayerDatas.countLevel++;
        LoadNextScene();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Update()
    {
        if (nextScene)
        {
            nextLevelPanel.SetActive(true);
        }
    }
}
