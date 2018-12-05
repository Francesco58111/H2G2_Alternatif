using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvariesManager : MonoBehaviour
{
    [Header("Events Parameters")]
    public float delayBeforeEvent;
    private int currentEvent = 0;
    public bool isEventLaunch;

    public static AvariesManager Instance;



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(LaunchEventIn());
    }

    /*
    void Update()
    {
        if(!isEventLaunch)
        {
            StartCoroutine(LaunchEventIn());
        }
        else
        {
            CheckEventStatus();
        }
    }
    */

    /// <summary>
    /// Lance une fonction à partir de x secondes
    /// </summary>
    /// <returns></returns>
    IEnumerator LaunchEventIn()
    {
        isEventLaunch = true;
        yield return new WaitForSeconds(delayBeforeEvent);
        LaunchEvent();
        StartCoroutine(LaunchEventIn());
    }

    private void LaunchEvent()
    {
        //StopAllCoroutines();
        currentEvent = UnityEngine.Random.Range(0, 2);
        PlayEvent(currentEvent);
        
    }

    /// <summary>
    /// Joue la fonction choisie au hasard
    /// </summary>
    /// <param name="selectedEvent"></param>
    void PlayEvent(int selectedEvent)
    {
        if (selectedEvent == 0 && HeatEvent.Instance.isOverheated == false)
        {
            HeatEvent.Instance.Overheating();
            //InputManager.Instance.ShuffleActions();
        }
        else
        {
            LaunchEvent();
        }


        if (selectedEvent == 1 && StainEvent.Instance.isThereAStain == false)
        {
            StainEvent.Instance.StainAppears();
            //InputManager.Instance.ShuffleActions();
        }
        else
        {
            LaunchEvent();
        }
        

        /*
        if (selectedEvent == 2)
            InputManager.Instance.ShuffleActions();
        */


        if (selectedEvent == 2 && AlarmEvent.Instance.isAlerteOn == false)
        {
            AlarmEvent.Instance.SetAlarm();
            //InputManager.Instance.ShuffleActions();
        }
        else
        {
            LaunchEvent();
        }
        
    }


    /// <summary>
    /// Check l'état de l'event et sa résolution avant dans lancer une autre
    /// </summary>
    void CheckEventStatus()
    {
        if (currentEvent == 0)
        {
            if (HeatEvent.Instance.isOverheated == false)
                isEventLaunch = false;
        }

        if (currentEvent == 1)
        {
            if (StainEvent.Instance.isThereAStain == false)
                isEventLaunch = false;
        }
    }
}
