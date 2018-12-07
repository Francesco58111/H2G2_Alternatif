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

    public bool onBoost;
    public bool canBoost;

    public static Boost Instance;
    public Scoring scoriiiiiing;
    public HyperspaceParticlesTransitions FX;



    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        boostBar.fillAmount = currentEnergy / energyMax;

        if (currentEnergy == energyMax)
            canBoost = true;

        if (onBoost)
        {
            BoostingTimer();
            FX.SetToLightSpeed();
        }
        else
        {
            FX.SetToNormalSpeed();
        }
    }


    /// <summary>
    /// Timer pour le boost
    /// </summary>
    private void BoostingTimer()
    {


        if (currentEnergy > 0)
        {
            currentEnergy -= 0.1f;
        }
        else
        {
            currentEnergy = 0;
            onBoost = false;
            scoriiiiiing.OffLightSpeed();
        }
    }


    /// <summary>
    /// Incrémente l'energy dans la barre
    /// </summary>
    public void AddEnergy()
    {
        if (currentEnergy < energyMax)
           currentEnergy += 1f;
    }
}
