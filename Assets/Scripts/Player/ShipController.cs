using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [Header("Déplacement")]

    public float speed = 10f; // Vitesse de déplacement


    //Coordonnées de chaque colonne du niveau
    public Vector3 premier;
    public Vector3 second;
    public Vector3 third;

    private Vector3 targetPosition;


    [Header("SetUp paramètres du vaisseau")]
    public int shield = 1;
    public int health = 3;
    public GameManager gameManager;



    void Start()
    {
        premier = new Vector3(-4, 0, 0);
        second = new Vector3(0.1f, 0, 0);
        third = new Vector3(4, 0, 0);
    }



    void Update()
    {


        PlayerMove();

        CheckHealth();


        

    }

    private void CheckHealth()
    {
        if (health<1)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void DamageTaken()
    {
        health -= 1;
    }


    /// <summary>
    /// Déplacement du joueur actualisé selon l'Input
    /// </summary>
    public void PlayerMove()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Left");
            targetPosition = premier;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("Middle");
            targetPosition = second;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Right");
            targetPosition = third;
        }

        if (targetPosition == transform.position)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    /*
    void Shooting()
    {
        GameObject obj = BulletsPooling.current.GetPooledObject();

        if (obj == null)
            return;

        //Set sa position sur la sienne et l'active
        obj.transform.position = playerPosition;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
    */

    /// <summary>
    /// Tir
    /// </summary>
 
    
}
