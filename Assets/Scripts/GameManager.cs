using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public string goBackToMenu = "MENU";

    public static GameManager Instance;

    //niveau de difficulté qui sert a check le multiple du niveau de difficulté
    private int currentDifficultyLevel;
    //niveau de difficulté actuel du jeu
    private int difficultyLevel;
    private int spawnEveryDifficultyLevel = 0;

    public Scoring scoreFloat;


    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //InvokeRepeating("InitializeSpawn", 0f, delay);
        delay = 0;
        isGameRunning = true;
        StartCoroutine(TestSpawn());
    }

    private void Update()
    {
        difficultyLevel = (int)scoreFloat.difficultyLevel;
        currentDifficultyLevel = difficultyLevel - spawnEveryDifficultyLevel;
        if (currentDifficultyLevel == 1)
        {
            spawnDelay = spawnDelay - (spawnDelay / 10);
            spawnEveryDifficultyLevel++;
            currentDifficultyLevel = 0;
        }
    }



    public void GameOver()
    {
        PlayerPrefs.SetInt("New Score", (int)score.score);
        SceneManager.LoadScene(goBackToMenu);
    }
    

    /// <summary>
    /// Débute le spawn d'un ennemy après un delai
    /// </summary>
    /// <returns></returns>
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



    /// <summary>
    /// Set l'apparition des ennemies aléatoirement
    /// </summary>
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


        //print("randomForPosition : " + randomForPosition);
        //print("MinRange : " + minRange + " / " + " MaxRange : " + maxRange);
        //print("spawnPosition : " + spawnPosition);
        InitializeSpawn();
    }


    /// <summary>
    /// Lance le spawn de l'ennemi
    /// </summary>
    void InitializeSpawn()
    {
        selectedSpawnPosition = spawnPosition;

        Spawn(spawnPos[selectedSpawnPosition]);
    }


    /// <summary>
    /// Vérifie l'état des ennemis puis set et spawn un d'entre eux (désactivé de base)
    /// </summary>
    /// <param name="selectedSpawn"></param>
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
