using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float score;
    public float incrementingSpeed;





    void Update()
    {
        if (ShipController.Instance.gameObject == true)
            ScoreUpdate();

        if (Input.GetKeyDown(KeyCode.N))
            OnLightSpeed();
    }



    public void OnLightSpeed()
    {
        Health.Instance.isInvisible = true;
        incrementingSpeed = 200;
        Boost.Instance.canBoost = false;
        Boost.Instance.onBoost = true;
    }



    public void OffLightSpeed()
    {
        Health.Instance.isInvisible = false;
        incrementingSpeed = 10;
    }



    /// <summary>
    /// Update le text du score s'incrémentant dans le temps
    /// </summary>
    void ScoreUpdate()
    {
        score += incrementingSpeed * Time.deltaTime;
        int newScore = (int)score;
        string updatedScore = newScore.ToString();
        text.SetText(updatedScore, true);
        
    }
}
