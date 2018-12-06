using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    [Header("SetUp Tir")]
    //Variables ajoutées par Emilie
    public GameObject bulletPrefab;
    public GameObject cameraMain;

    private bool cooldown = true;
    Vector3 playerPosition;
    public float shootingReload;

    public bool canShoot = true;

    public HeatEvent heat;

    public static ShootScript Instance;




    private void Awake()
    {
        Instance = this;
    }

    void Update () {

        playerPosition = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, cameraMain.transform.position.z);

        if (Input.GetKeyDown("space") && cooldown && canShoot)
        {
            Shoot();
        }
    
    }

    private void Shoot()
    {

        Instantiate<GameObject>(bulletPrefab, playerPosition, Quaternion.identity);
        heat.currentHeat += 2;
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
