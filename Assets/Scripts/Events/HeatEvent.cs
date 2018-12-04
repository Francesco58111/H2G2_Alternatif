﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatEvent : MonoBehaviour
{

    public bool isOverheated;
    public Image weaponHeat;
    public Image overheat;

    public float currentHeat;
    private float maxHeat = 10;

    private float cooldownSpeed;
    public float highSpeed;
    public float lowSpeed;
    
    


    public static HeatEvent Instance;




    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        weaponHeat.fillAmount = (currentHeat / maxHeat);

        if (!isOverheated)
            Cooldown();
        else
            Overheating();
    }

    /// <summary>
    /// Etat de surchauffe
    /// </summary>
    public void Overheating()
    {
        ShootScript.Instance.canShoot = false;
        overheat.gameObject.SetActive(true);
        //currentHeat = maxHeat;

        if (currentHeat < 0)
        {
            isOverheated = false;
        }
    }

    /// <summary>
    /// Décroit la surchauffe
    /// </summary>
    public void CoolDownBoost()
    {
        currentHeat -= 2;
    }

    


    /// <summary>
    /// Update le cooldown et la jauge de surchauffe selon l'état du currentHeat
    /// </summary>
    private void Cooldown()
    {
        currentHeat -= Time.deltaTime * cooldownSpeed;

        ShootScript.Instance.canShoot = true;
        

        if (currentHeat < 7)
        {
            overheat.gameObject.SetActive(false);
            cooldownSpeed = highSpeed;
        }

        if (currentHeat < 0)
        {

            cooldownSpeed = 0;
        }

        if (currentHeat > 7 && currentHeat < 10)
        {
            cooldownSpeed = highSpeed;
            overheat.gameObject.SetActive(true);
        }

        if (currentHeat>maxHeat)
        {
            isOverheated = true;
        }
    }
}
