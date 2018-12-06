using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public string sceneToLoad = "FINAL";

    private int newScore;

    public List<TextMeshProUGUI> scoreSlots;
    public List<int> scores;




    private void Start()
    {
        Load();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(sceneToLoad);
    }


    public void Load()
    {
        newScore = PlayerPrefs.GetInt("New Score");
        SetNewScore();
    }


    private void SetNewScore()
    {
        for (int i = 0; i < scoreSlots.Count; i++)
        {
            if(newScore > scores[i])
            {
                scores.Insert(i, newScore);
                scores.Remove(5);
                scoreSlots[i].text = newScore.ToString();

                break;
            }
        }
    }
}
