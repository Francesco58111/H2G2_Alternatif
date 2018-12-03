using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public float delay;
    public bool isGameRunning;
    public List<Transform> spawnPos;
    private int selectedSpawnPosition;
    private int spawnPosition;
    public float spawnDelay;

    public Scoring score;

    //float pour random la position de spawn
    private float randomForPosition = 0;

    //valeur de la tranche nécéssaire pour spawn a un endroit donnée
    public float minRange = 33;
    public float maxRange = 66;





    private void Start()
    {
        //InvokeRepeating("InitializeSpawn", 0f, delay);
        delay = 0;
        isGameRunning = true;
        StartCoroutine(TestSpawn());
    }


    private void Update()
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

                RandomSpawn();
            }

            yield return null;
        }
    }

    void RandomSpawn()
    {
        randomForPosition = Random.Range(0, 100);
        if (0 < randomForPosition && randomForPosition < minRange)
        {
            spawnPosition = 0;
            minRange = minRange - 10;
            maxRange = maxRange - 5;
        }
        else if (minRange < randomForPosition && randomForPosition < maxRange)
        {
            spawnPosition = 1;
            minRange = minRange + 5;
            maxRange = maxRange - 5;
        }
        else if (maxRange < randomForPosition && randomForPosition < 100)
        {
            spawnPosition = 2;
            maxRange = maxRange + 10;
            minRange = minRange + 5;
        }


        print("randomForPosition : " + randomForPosition);
        print("MinRange : " + minRange + " / " + " MaxRange : " + maxRange);
        print("spawnPosition : " + spawnPosition);
        InitializeSpawn();
    }

    void InitializeSpawn()
    {
        selectedSpawnPosition = spawnPosition;

        Spawn(spawnPos[selectedSpawnPosition]);
    }


    private void Spawn(Transform selectedSpawn)
    {
        GameObject obj = EnnemyPooling.currentState.GetPooledObject();

        if (obj == null)
            return;

        obj.transform.position = selectedSpawn.position;
        obj.transform.rotation = selectedSpawn.rotation;
        obj.SetActive(true);
    }
}
