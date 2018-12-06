using System.Collections;
using UnityEngine;

public class AvariesManager : MonoBehaviour
{
    [Header("Events Parameters")]
    public float delayBeforeEvent;
    [SerializeField]
    private int currentEvent = 0;
    private int lastEvent;
    public bool isEventLaunch;

    public InputManager inputManager;
    public StainEvent stainEvent;
    public AlarmEvent alarmEvent;
    public HeatEvent heatEvent;





    private void Start()
    {
        StartCoroutine(LaunchEventIn());
        //LaunchEvent();
    }

    
    void Update()
    {
        /*
        if(!isEventLaunch)
        {
            StartCoroutine(LaunchEventIn());
        }
        else
        {
            CheckEventStatus();
        }
        */
    }
    

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
        if(currentEvent == lastEvent)
            currentEvent = Random.Range(0, 2);
        PlayEvent(currentEvent);
        
    }

    /// <summary>
    /// Joue la fonction choisie au hasard
    /// </summary>
    /// <param name="selectedEvent"></param>
    void PlayEvent(int selectedEvent)
    {
        lastEvent = currentEvent;

        if (selectedEvent == 0 && heatEvent.isOverheated == false)
        {
            heatEvent.Overheating();
            inputManager.ShuffleActions();
        }


        if (selectedEvent == 1 && stainEvent.isThereAStain == false)
        {
            stainEvent.StainAppears();
            inputManager.ShuffleActions();
        }
        

        /*
        if (selectedEvent == 2)
            InputManager.Instance.ShuffleActions();
        */


        if (selectedEvent == 2 && alarmEvent.isAlerteOn == false)
        {
            alarmEvent.SetAlarm();
            inputManager.ShuffleActions();
        }
        
    }


    /// <summary>
    /// Check l'état de l'event et sa résolution avant dans lancer une autre
    /// </summary>
    void CheckEventStatus()
    {
        if (currentEvent == 0)
        {
            if (heatEvent.isOverheated == false)
                isEventLaunch = false;
        }

        if (currentEvent == 1)
        {
            if (stainEvent.isThereAStain == false)
                isEventLaunch = false;
        }
    }
}
