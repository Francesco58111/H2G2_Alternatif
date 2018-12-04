using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    [Header("Events Parameters")]
    public float delayBeforeEvent;
    private int currentEvent;
    public bool isEventLaunch;

    public static EventsManager Instance;



    private void Awake()
    {
        Instance = this;
    }
    
    
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

    /// <summary>
    /// Lance une fonction à partir de x secondes
    /// </summary>
    /// <returns></returns>
    IEnumerator LaunchEventIn()
    {
        isEventLaunch = true;
        yield return new WaitForSeconds(delayBeforeEvent);
        currentEvent = UnityEngine.Random.Range(0, 1); ;
        PlayEvent(currentEvent);
    }

    /// <summary>
    /// Joue la fonction choisie au hasard
    /// </summary>
    /// <param name="selectedEvent"></param>
    void PlayEvent(int selectedEvent)
    {
        if (selectedEvent == 0 && HeatEvent.Instance.isOverheated == false)
            HeatEvent.Instance.Overheating();

        if (selectedEvent == 1 && StainEvent.Instance.isThereAStain == false)
            StainEvent.Instance.StainAppears();
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
