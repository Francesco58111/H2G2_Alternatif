using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBehavior : MonoBehaviour {


    [Header("Déplacement Boost")]
    public Rigidbody boostRigidBody;

    public float ennemySpeed = 100;


    private void Start()
    {
        
    }

    private void Update()
    {
        boostRigidBody.velocity = Vector3.back * ennemySpeed * Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("boost récuperer");
            Boost.Instance.AddEnergy();
            Destroy(gameObject);
        }
    }
}
