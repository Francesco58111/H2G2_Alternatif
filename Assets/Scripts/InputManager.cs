using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class InputManager : MonoBehaviour
{

    public List<Button> buttons;
    public List<Text> buttonTextes;
    public List<String> actions;
    public int actionSelected = 1;
    //public ShipController shipController;





    private void Start()
    {
        //Set la list une première fois et la mélange
        actions = new List<string> { "GoLeft", "GoMiddle", "GoRight", "Cafe", "Toast", "EssuieGlace", "Gaz", "Barbecue", "Boost", "Alarme" };
        ShuffleActions();
    }

    /// <summary>
    /// Associe les actions aux index
    /// </summary>
    /// <param name="actionIndex"></param>
    void SetActions(int actionIndex)
    {
        if (actions[actionIndex] == "GoLeft")
        {
            print("Set Left");
            ShipController.Instance.GoLeft();
            
        }

        if (actions[actionIndex] == "GoMiddle")
        {
            ShipController.Instance.GoMiddle();
        }

        if (actions[actionIndex] == "GoRight")
        {
            ShipController.Instance.GoRight();
        }

        if (actions[actionIndex] == "Cafe")
        {
            print("Faire du café");
        }

        if (actions[actionIndex] == "Toast")
        {
            print("Toaster en route");
        }

        if (actions[actionIndex] == "EssuieGlace")
        {
            print("Essuie Glace");
        }

        if (actions[actionIndex] == "Gaz")
        {
            print("Surplus de gaz");
        }

        if (actions[actionIndex] == "Barbecue")
        {
            print("Allumage du Barbecue");
        }

        if (actions[actionIndex] == "Boost")
        {
            print("Vitesse lumière");
        }

        if (actions[actionIndex] == "Alarme")
        {
            print("Alerte ! Il y a une alerte !");
        }
    }


    /// <summary>
    /// Réalise selon l'input l'action donnée
    /// </summary>
    void Update()
    {
        //Input A
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetActions(0);
            buttons[0].image.color = Color.black;
        }
        else
        {
            buttons[0].image.color = Color.white;
        }

        //Input Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetActions(1);
            buttons[1].image.color = Color.black;
        }
        else
        {
            buttons[1].image.color = Color.white;
        }

        //Input E
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetActions(2);
            buttons[2].image.color = Color.black;
        }
        else
        {
            buttons[2].image.color = Color.white;
        }

        //Input R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetActions(3);
            buttons[3].image.color = Color.black;
        }
        else
        {
            buttons[3].image.color = Color.white;
        }

        //Input T
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetActions(4);
            buttons[4].image.color = Color.black; 
        }
        else
        {
            buttons[4].image.color = Color.white;
        }

        //Input Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetActions(5);
            buttons[5].image.color = Color.black; 
        }
        else
        {
            buttons[5].image.color = Color.white;
        }

        //Input S
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetActions(6);
            buttons[6].image.color = Color.black;
        }
        else
        {
            buttons[6].image.color = Color.white;
        }

        //Input D
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetActions(7);
            buttons[7].image.color = Color.black;
        }
        else
        {
            buttons[7].image.color = Color.white;
        }

        //Input F
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetActions(8);
            buttons[8].image.color = Color.black;
        }
        else
        {
            buttons[8].image.color = Color.white;
        }

        //Input G
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetActions(9);
            buttons[9].image.color = Color.black;
        }
        else
        {
            buttons[9].image.color = Color.white;
        }
    }

    /// <summary>
    /// Mélange les actions x fois
    /// </summary>
    void ShuffleActions()
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
        randomIndex = UnityEngine.Random.Range(0, actions.Count-1);
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
