using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBehaviour : MonoBehaviour
{

    [Header("Viser")]

    //Récupération du rigidbody
    public Rigidbody rb;
    //Set de la vitesse du curseur
    public float aimSpeed = 10;
    //viseur hauteur gagné up/down
    public float heigh;

    //vecteur viseur
    private Vector3 upArrowVector;
    private Vector3 downArrowVector;



    private void Start()
    {
        upArrowVector = new Vector3(0, heigh, 0);
        downArrowVector = new Vector3(0, -heigh, 0);
    }


    void Update()
    {
        //Update de la direction

        if (Input.GetKey(KeyCode.UpArrow))
            Aiming(upArrowVector);
        if (Input.GetKey(KeyCode.DownArrow))
            Aiming(downArrowVector);

        if (Input.GetKey(KeyCode.LeftArrow))
            Aiming(Vector3.left);
        if (Input.GetKey(KeyCode.RightArrow))
            Aiming(Vector3.right);


    }


    /// <summary>
    /// Déplacement du curseur avec son rigidbody
    /// </summary>
    /// <param name="direction"></param>
    public void Aiming(Vector3 direction)
    {
        rb.velocity = direction * aimSpeed * Time.deltaTime;
    }
}
