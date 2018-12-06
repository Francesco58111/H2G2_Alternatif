using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    [Header("Aim SetUp")]
    public GameObject viseur;
    public GameObject cam;
    

    public float bulletSpeed = 10f;
    public float durability = 1;
    public int damage = 1; //Dommages infligés
    public float lifeTime = 10; //Durée de vie de la balle

    private Vector3 targetVector;

    [Header("Récupération du script Ennemy")]
    public EnnemyBehaviour ennemyBehaviour;
    public EnnemieShooterBehavior ennemieShooterBehavior;



    private void Awake()
    {
        if (ennemyBehaviour == null)
        {
            
        }

        viseur = GameObject.Find("AimTarget");
        cam = GameObject.Find("Main Camera");

        Vector3 viseurPosition = viseur.transform.position;
        Vector3 playerPosition = cam.transform.position;

        //Direction de la visée
        targetVector = viseurPosition - playerPosition;
    }


    public void Update()
    {
        transform.Translate(targetVector * Time.deltaTime*bulletSpeed);
        Destroy(this, lifeTime);
    }

    /// <summary>
    /// Collision avec un ennemy
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            print("Touché");

            
            other.gameObject.GetComponent<EnnemyBehaviour>().TakingDamage(damage);
            
            /*
            if (ennemyBehaviour == null)
            {
                ennemyBehaviour = other.gameObject.GetComponent<EnnemyBehaviour>();
            }
            ennemyBehaviour.TakingDamage(damage);
            */
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "EnnemyShooter")
        {
            print("Touché");


            other.gameObject.GetComponent<EnnemieShooterBehavior>().TakingDamage(damage);

            /*
            if (ennemyBehaviour == null)
            {
                ennemyBehaviour = other.gameObject.GetComponent<EnnemyBehaviour>();
            }
            ennemyBehaviour.TakingDamage(damage);
            */
            this.gameObject.SetActive(false);
        }


        
    }


}
