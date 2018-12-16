using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBehavior : MonoBehaviour {


    [Header("Déplacement Boost")]
    public Rigidbody boostRigidBody;

    public float ennemySpeed = 100;

    public ParticleSystem explosion;
    public MeshRenderer mesh;




    private void Update()
    {
        boostRigidBody.velocity = Vector3.back * ennemySpeed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //FXManager.Instance.InitializePS(ps, this.transform);
            print("boost récuperer");
            Boost.Instance.AddEnergy();
            StartCoroutine(Dying());
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
