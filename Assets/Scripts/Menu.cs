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

    public AudioClip musicClip;
    public AudioSource musicSource;

    private bool canStart;




    private void Start()
    {
        SetNewScores();
        musicSource.clip = musicClip;
        musicSource.Play();
        canStart = false;
        StartCoroutine(delayBeforeStart());
    }

    private void SetNewScores()
    {
        newScore = PlayerPrefs.GetInt("New Score");
        lastScore = PlayerPrefs.GetInt("un");
        PrintScores();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canStart == true)
        {
            musicSource.Stop();
            SceneManager.LoadScene(sceneToLoad);
        }  
    }

    private void PrintScores()
    {
        bestScore.text = lastScore.ToString();
        yourScore.text = newScore.ToString();
    }

    IEnumerator delayBeforeStart()
    {
        yield return new WaitForSeconds(2);
        canStart = true;
    }
}
