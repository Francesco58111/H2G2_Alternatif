using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;
    public float incrementingSpeed;


    void Update()
    {
        ScoreUpdate();
    }

    /// <summary>
    /// Update le text du score s'incrémentant dans le temps
    /// </summary>
    void ScoreUpdate()
    {
        score += (int)(incrementingSpeed * Time.deltaTime);
        string newScore = score.ToString();
        text.SetText(newScore);
    }
}
