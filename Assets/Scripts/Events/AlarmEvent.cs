﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEvent : MonoBehaviour
{
    [Header("SetUp Son")]
    public AudioClip alarmClip;
    public AudioSource alarmSource;
    public GameObject alarmIcon;
    public GameObject alarmIcon2;

    public bool isAlerteOn = false;




    private void Awake()
    {
        alarmSource.clip = alarmClip;
    }


    /// <summary>
    /// Active/Désactive le son de l'alerte
    /// </summary>
    public void SetAlarm()
    {
        if (!isAlerteOn)
        {
            alarmSource.Play();
            isAlerteOn = true;
            alarmIcon.SetActive(true);
            alarmIcon2.SetActive(true);
        }
        else
        {
            alarmSource.Stop();
            isAlerteOn = false;
            alarmIcon.SetActive(false);
            alarmIcon2.SetActive(false);
        }
        
    }
}
