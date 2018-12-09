using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour {

    public List<Transform> spawnPos;

    private int randomSpawnPosition;

    public GameObject boostPrefab;

    private float score;
    private float scoreReseter;
    private float scoreChecker;



    public Scoring scoreFloat;

    public float scoreForBoostSpawn = 20;
    public float delayBoostAppears = 2;




    private void Start()
    {
        StartCoroutine(boostApparitionTimer());
    }


    IEnumerator boostApparitionTimer()
    {
        yield return new WaitForSeconds(delayBoostAppears);
        randomBoostSpawn();
        StartCoroutine(boostApparitionTimer());
    }

    void Update ()
    {
        /*
        score = (float)scoreFloat.score;
        scoreChecker = score - scoreReseter ;


        if ( scoreChecker >= scoreForBoostSpawn)
        {

            scoreReseter = score;
            scoreChecker = 0;
            randomBoostSpawn();

        }
        */
    }

    void randomBoostSpawn()
    {
        randomSpawnPosition = Random.Range(1, 3);
        if (randomSpawnPosition == 1)
        {
            Instantiate<GameObject>(boostPrefab, spawnPos[0]);
        }
        else if (randomSpawnPosition == 2)
        {
            Instantiate<GameObject>(boostPrefab, spawnPos[1]);
        }
        else if (randomSpawnPosition == 3)
        {
            Instantiate<GameObject>(boostPrefab, spawnPos[2]);
        }
    }
}
