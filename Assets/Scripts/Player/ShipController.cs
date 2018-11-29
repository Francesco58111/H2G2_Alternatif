using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [Header("Déplacement")]

    public float speed = 10f; // Vitesse de déplacement
    public float shootingReload;

    //Coordonnées de chaque colonne du niveau
    public Vector3 left;
    public Vector3 middle;
    public Vector3 right;

    public Vector3 targetPosition;

    [Header("SetUp Tir")]
    //Variables ajoutées par Emilie
    public GameObject bulletPrefab;
    public GameObject player;
    private bool cooldown = true;
    Vector3 playerPosition;

    [Header("SetUp paramètres du vaisseau")]
    public int shield = 1;
    public int health = 3;
    public GameManager gameManager;



    void Start()
    {
        left = new Vector3(-4, 0, 0);
        middle = new Vector3(0.1f, 0, 0);
        right = new Vector3(4, 0, 0);
    }



    void Update()
    {

        PlayerMove();

        CheckHealth();

        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if (Input.GetKeyDown("space") && cooldown)
        {
            Shoot();
        }

        

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
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            GoLeft();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GoMiddle();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GoRight();
        }
        */

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
    private void Shoot()
    {
        Instantiate<GameObject>(bulletPrefab, playerPosition, Quaternion.identity);
        cooldown = false;
        StartCoroutine(Reload());
    }

    /// <summary>
    /// Temps de recharge
    /// </summary>
    /// <returns></returns>
    IEnumerator Reload()
    { 
        yield return new WaitForSeconds(shootingReload);
        cooldown = true;
    }
    
}
