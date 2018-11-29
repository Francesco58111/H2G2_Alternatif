using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    [Header("SetUp Tir")]
    //Variables ajoutées par Emilie
    public GameObject bulletPrefab;
    public GameObject player;
    private bool cooldown = true;
    Vector3 playerPosition;
    public float shootingReload;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if (Input.GetKeyDown("space") && cooldown)
        {
            Shoot();
        }
    
    }
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
