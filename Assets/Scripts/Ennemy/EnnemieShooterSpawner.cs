using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieShooterSpawner : MonoBehaviour {

    public bool isGameRunning = false;

    public GameObject ennemieShooter;

    public Scoring scoreFloat;

    //spawnrate
    private float delay ;
    public float spawnDelay = 8;

    //spawnrange
    public float minSpawnRangeX = 20;
    public float minSpawnRangeY = 20;
    private float maxSpawnRangeX = 20;
    private float maxSpawnRangeY = 20;

    public Transform spawnerObjectPosition;

    private Vector3 spawnPosition;

    //niveau de difficulté qui sert a check le multiple du niveau de difficulté
    private int currentDifficultyLevel;
    //niveau de difficulté actuel du jeu
    private int difficultyLevel;
    private int spawnEveryDifficultyLevel = 0;


    private void Start()
    {
        isGameRunning = true;
        maxSpawnRangeX = -minSpawnRangeX;
        maxSpawnRangeY = -minSpawnRangeY;
        StartCoroutine(TestSpawn());
    }

	

	void Update ()
    {
        spawnPosition = new Vector3(Random.Range(minSpawnRangeX,maxSpawnRangeX),Random.Range(minSpawnRangeY,maxSpawnRangeY),spawnerObjectPosition.position.z);

        difficultyLevel = (int)scoreFloat.difficultyLevel;
        currentDifficultyLevel = difficultyLevel - spawnEveryDifficultyLevel;
        if (currentDifficultyLevel == 1)
        {
            spawnDelay = spawnDelay - (spawnDelay /10);
            spawnEveryDifficultyLevel++;
            currentDifficultyLevel = 0;
        }


    }

    void StartMovement()
    {

    }

    IEnumerator TestSpawn()
    {
        while (isGameRunning)
        {
            delay += Time.deltaTime;

            if (delay > spawnDelay)
            {
                delay = 0;

                Spawn();
            }

            yield return null;
        }
    }

    void Spawn()
    {
            GameObject Temp = Instantiate<GameObject>(ennemieShooter, spawnPosition, Quaternion.Euler(90, 0, 0));
            Temp.transform.SetParent(this.transform);

       

    }
}
