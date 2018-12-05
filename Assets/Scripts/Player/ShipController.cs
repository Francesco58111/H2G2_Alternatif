using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [Header("Déplacement")]

    public float speed = 10f; // Vitesse de déplacement

    //Coordonnées de chaque colonne du niveau
    public Vector3 left;
    public Vector3 middle;
    public Vector3 right;

    public Vector3 targetPosition;

    public static ShipController Instance;




    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        left = new Vector3(-1, 0, 0);
        middle = new Vector3(0.1f, 0, 0);
        right = new Vector3(1, 0, 0);
    }



    void Update()
    {
        PlayerMove();
    }

    /// <summary>
    /// Déplacement du joueur actualisé selon l'Input
    /// </summary>
    public void PlayerMove()
    {
        if (targetPosition == transform.position)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void GoRight()
    {
        targetPosition = right;
    }

    public void GoMiddle()
    {
        targetPosition = middle;
    }

    public void GoLeft()
    {
        targetPosition = left;
    }   
}
