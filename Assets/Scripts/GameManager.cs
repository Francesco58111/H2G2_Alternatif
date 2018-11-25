using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float delay;
    public List<Transform> spawnPos;
    private int selectedSpawnPosition;

    public ShipController shipController;
    public Scoring score;

    private void Start()
    {
        InvokeRepeating("InitializeSpawn", 0f, delay);
    }


    void InitializeSpawn()
    {
        selectedSpawnPosition = Random.Range(0, 2);

        Spawn(spawnPos[selectedSpawnPosition]);
    }


    private void Spawn(Transform selectedSpawn)
    {
        GameObject obj = EnnemyPooling.currentState.GetPooledObject();

        if (obj == null)
            return;

        //Set sa position sur la sienne et l'active
        obj.transform.position = selectedSpawn.position;
        obj.transform.rotation = selectedSpawn.rotation;
        obj.SetActive(true);
    }
}
