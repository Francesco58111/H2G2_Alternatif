using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    [Header("Déplacement Ennemy")]
    public Rigidbody ennemyRigidbody;

    public float ennemySpeed = 100;


    [Header("Vie de l'ennemy")]
    [SerializeField]
    int ennemyHealth = 3;

    public ParticleSystem explosion;
    public MeshRenderer mesh;






    void Update()
    {
        CheckingHealth();

        EnnemyMove();
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
            StartCoroutine(Dying());
            //ennemyHealth = 3;
        }
    }

    /// <summary>
    /// Déplacement de l'ennemy en -z
    /// </summary>
    private void EnnemyMove()
    {
        ennemyRigidbody.velocity = Vector3.back * ennemySpeed * Time.deltaTime;
    }



    /// <summary>
    /// Récupère le nombre de GameObject dans le pooling
    /// </summary>


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
        Health.Instance.LosingHealth();
        StartCoroutine(Dying());
    }

    IEnumerator Dying()
    {
        var duration = explosion.main.duration;
        mesh.enabled = false;
        explosion.Play();
        yield return new WaitForSeconds(duration);
        this.gameObject.SetActive(false);
        ennemyHealth = 3;
    }
}
