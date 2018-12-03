using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawn : MonoBehaviour {

    public GameObject ennemyPrefab;


    public Transform playerTransform;


    public float RangeSpawn=10;
    public float spawnSquareLengh = 5;
    public float spawnSquareHeigth = 5;

    public float spawntime = 20;

    private Vector3 distanceSpawn;


	void Start ()
    {
        StartCoroutine(Spawn());
    }
	

	void Update ()
    {
       
        distanceSpawn = new Vector3(Random.Range(-spawnSquareLengh, spawnSquareLengh), Random.Range(-spawnSquareHeigth, spawnSquareHeigth), RangeSpawn);

     }

    IEnumerator Spawn()
    {
        Instantiate<GameObject>(ennemyPrefab, playerTransform.position, Quaternion.identity);
        StopCoroutine(Spawn());
        yield return new WaitForSeconds(spawntime);
    }
}
