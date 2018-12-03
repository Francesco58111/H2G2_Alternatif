using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletBehaviour : MonoBehaviour
{
    [Header("SetUp bullets values")]
    public float ennemyBulletSpeed = 10;
    private Rigidbody rb;
    public ShipController shipController;


    void Awake()
    {
        if(rb == null)
            rb = this.GetComponent<Rigidbody>();

    }

    void Update()
    {
        //Déplacement de la bullet en -z
        rb.velocity = Vector3.back * ennemyBulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Health.Instance.LosingHealth();
            this.gameObject.SetActive(false);
        }
    }
}
