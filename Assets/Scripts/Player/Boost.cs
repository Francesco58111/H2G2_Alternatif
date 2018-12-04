using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boost : MonoBehaviour
{
    [Header("Set up parameters")]
    public float currentEnergy = 0;
    [SerializeField]
    float energyMax = 10;
    public Image boostBar;

    public float lightSpeedDuration = 1;


    public bool canBoost;

    public static Boost Instance;



    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (currentEnergy == energyMax)
            canBoost = true;
    }

    public void AddEnergy()
    {
        if (currentEnergy < energyMax)
            boostBar.fillAmount += 0.1f;
    }


    public void LightSpeedOn()
    {
        Health.Instance.isInvisible = true;
        Scoring.Instance.boostSpeed = 4;
    }

    public void LightSpeedOff()
    {
        Health.Instance.isInvisible = false;
        Scoring.Instance.boostSpeed = 1;
    }

    public IEnumerator OnLightSpeed()
    {
        LightSpeedOn();
        yield return new WaitForSeconds(lightSpeedDuration);
        LightSpeedOff();
    }
}
