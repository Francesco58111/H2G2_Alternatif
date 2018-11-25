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




    void Update()
    {
        //Update de la direction
        
        if (Input.GetKey(KeyCode.UpArrow))
            Aiming(Vector3.forward);
        if (Input.GetKey(KeyCode.DownArrow))
            Aiming(Vector3.back);
        
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
