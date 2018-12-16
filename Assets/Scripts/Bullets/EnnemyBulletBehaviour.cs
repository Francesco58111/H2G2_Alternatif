using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletBehaviour : MonoBehaviour
{
    [Header("SetUp bullets values")]
    public float ennemyBulletSpeed = 10;

    public ShipController shipController;

    public Transform playerTransform;

    private Vector3 bulletVector;

    public ParticleSystem explosion;
    public MeshRenderer mesh;





    void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        bulletVector = new Vector3(playerTransform.position.x-gameObject.transform.position.x , playerTransform.position.y - gameObject.transform.position.y, playerTransform.position.z - gameObject.transform.position.z);

    }

    void Update()
    {
        transform.Translate(bulletVector * ennemyBulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Dying());
            Health.Instance.LosingHealth();
        }
    }

    IEnumerator Dying()
    {
        var duration = explosion.main.duration;
        mesh.enabled = false;
        explosion.Play();
        yield return new WaitForSeconds(duration);
        this.gameObject.SetActive(false);
    }
}
