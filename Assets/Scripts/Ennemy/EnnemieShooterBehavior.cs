using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnnemieShooterBehavior : MonoBehaviour {

    [Header("Déplacement Ennemy")]
    public Rigidbody ennemyRigidbody;

    public float ennemySpeed = 100;
    private float delay;
    public float moveTime = 4;
    public float reloadDelay = 5;


    [Header("Vie de l'ennemy")]
    [SerializeField]
    int ennemyHealth = 3;

    public GameObject ennemieBullet;

    public GameObject parentObject;




    private void Start()
    {
        //Tir toutes les "firetime" seconde(s)
        ennemyHealth = 1;
        moveTime = 1;

    }
    private void Awake()
    {
        StartCoroutine(Shoot());
    }
    void Update()
    {
        CheckingHealth();
        if ( moveTime >0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * ennemySpeed);
            moveTime -= Time.deltaTime;
        }
        




    }

    /// <summary>
    /// Inflige des dégâts
    /// </summary>
    /// <param name="damage"></param>
    public void TakingDamage(int damage)
    {
        ennemyHealth -= damage;
    }


    /// <summary>
    /// Check la vie de l'ennemy
    /// </summary>
    private void CheckingHealth()
    {
        if (ennemyHealth < 1)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Collision avec le player _ GAME OVER
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DeadCollision();
        }
    }


    /// <summary>
    /// Désactivation de l'ennemy pour le pooling
    /// </summary>
    private void DeadCollision()
    {
        //Destroy(this.gameObject);
    }

    IEnumerator Shoot()
    {
        for (; ;)
        {
            Instantiate<GameObject>(ennemieBullet,gameObject.transform.position,Quaternion.identity);
            print("is in coroutine");
            yield return new WaitForSeconds(reloadDelay);
        }

    }

}

