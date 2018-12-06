using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class InputManager : MonoBehaviour
{

    public List<TMP_InputField> buttons;
    public List<TextMeshProUGUI> buttonTextes;
    private List<String> actions;
    public int actionSelected = 1;

    public Scoring scoriiiiiing;
    public StainEvent stain;
    public HeatEvent overheat;
    public AlarmEvent alerte;

    public static InputManager Instance;




    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //Set la list une première fois et la mélange
        actions = new List<string> { "Gauche", "Milieu", "Droite", "Lave-Vitre", "Refroidir", "Boost", "Alarme" };
        ShuffleActions();
    }

    /// <summary>
    /// Associe les actions aux index
    /// </summary>
    /// <param name="actionIndex"></param>
    void SetActions(int actionIndex)
    {
        if (actions[actionIndex] == "Gauche")
        {
            ShipController.Instance.GoLeft();            
        }

        if (actions[actionIndex] == "Milieu")
        {
            ShipController.Instance.GoMiddle();
        }

        if (actions[actionIndex] == "Droite")
        {
            ShipController.Instance.GoRight();
        }

        if (actions[actionIndex] == "Lave-Vitre")
        {
            print("Lave-Vitre");
            stain.Wip();
        }

        if (actions[actionIndex] == "Refroidir")
        {
            print("Refroidissement des machines");
            overheat.CoolDownBoost();
        }

        if (actions[actionIndex] == "Boost")
        {
            
            if(Boost.Instance.canBoost == true)
            {
                print("Vitesse lumière");
                scoriiiiiing.OnLightSpeed();
            }
        }

        if (actions[actionIndex] == "Alarme")
        {
            print("Alerte ! Il y a une alerte !");
            alerte.SetAlarm();
        }
    }


    /// <summary>
    /// Réalise selon l'input l'action donnée
    /// </summary>
    void Update()
    {
        InputToAction();
    }

    /// <summary>
    /// Déclenche une action selon l'input
    /// </summary>
    private void InputToAction()
    {
        //Input A
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetActions(0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            buttons[0].image.color = Color.white;
        }
        else
        {
            buttons[0].image.color = Color.yellow;
        }


        //Input Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetActions(1);
            buttons[1].image.color = Color.white;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            buttons[1].image.color = Color.white;
        }
        else
        {
            buttons[1].image.color = Color.yellow;
        }


        //Input E
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetActions(2);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            buttons[2].image.color = Color.white;
        }
        else
        {
            buttons[2].image.color = Color.yellow;
        }


        //Input R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetActions(3);
        }

        if (Input.GetKey(KeyCode.R))
        {
            buttons[3].image.color = Color.white;
        }
        else
        {
            buttons[3].image.color = Color.yellow;
        }


        //Input T
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetActions(4);
        }

        if (Input.GetKey(KeyCode.T))
        {
            buttons[4].image.color = Color.white;
        }
        else
        {
            buttons[4].image.color = Color.yellow;
        }


        //Input Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetActions(5);
        }


        if (Input.GetKey(KeyCode.Y))
        {
            buttons[5].image.color = Color.white;
        }
        else
        {
            buttons[5].image.color = Color.yellow;
        }


        //Input U
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetActions(6);
        }

        if (Input.GetKey(KeyCode.U))
        {
            buttons[6].image.color = Color.white;
        }
        else
        {
            buttons[6].image.color = Color.yellow;
        }
    }

    /// <summary>
    /// Mélange les actions x fois
    /// </summary>
    public void ShuffleActions()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            ShuffleAction();
        }

        SetActionToButton();
    }

    /// <summary>
    /// Insert une action 
    /// </summary>
    void ShuffleAction()
    {
        int randomIndex;
        //print(actions.Count);
        randomIndex = UnityEngine.Random.Range(0, actions.Count);
        actions.Insert(0, actions[randomIndex]);
        actions.RemoveAt(randomIndex + 1);
    }

    /// <summary>
    /// Accorde le text de l'input à sa nouvelle action assignée
    /// </summary>
    void SetActionToButton()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttonTextes[i].text = actions[i];
        }
    }
}
