using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public string sceneToLoad = "FINAL";

    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI yourScore;

    public int newScore;
    public int lastScore;




    private void Start()
    {
        SetNewScores();
    }

    private void SetNewScores()
    {
        newScore = PlayerPrefs.GetInt("New Score");
        lastScore = PlayerPrefs.GetInt("un");
        PrintScores();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(sceneToLoad);
    }

    private void PrintScores()
    {
        bestScore.text = lastScore.ToString();
        yourScore.text = newScore.ToString();
    }
}
