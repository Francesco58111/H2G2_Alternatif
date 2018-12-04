using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;
    public float incrementingSpeed;

    public int boostSpeed = 1;

    public static Scoring Instance;




    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        ScoreUpdate();
    }

    /// <summary>
    /// Update le text du score s'incrémentant dans le temps
    /// </summary>
    void ScoreUpdate()
    {
        score += (int)(incrementingSpeed * Time.deltaTime) * boostSpeed;
        string newScore = score.ToString();
        text.SetText(newScore);
    }
}
