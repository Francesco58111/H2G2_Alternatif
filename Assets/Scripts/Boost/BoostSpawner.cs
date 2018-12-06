using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour {

    public List<Transform> spawnPos;

    private int randomSpawnPosition;

    public GameObject boostPrefab;

    private int actualScore;

    private int scoreChecker;
    private int score;

    private Scoring scoreFloat;

    public float scoreForBoostSpawn = 500;




    void Start () {
		
	}
	

	void Update ()
    {
        actualScore = (int)scoreFloat.score;
        scoreChecker = actualScore - score ;

        if ( scoreChecker >= scoreForBoostSpawn)
        {
            randomBoostSpawn();
            score = actualScore;
            scoreChecker = 0;
            
        }
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
