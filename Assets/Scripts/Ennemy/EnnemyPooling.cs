using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPooling : MonoBehaviour {

    public static EnnemyPooling currentState;
    public GameObject Ennemy;
    public int ennemyAmount = 10;
    public bool addOrNotToAdd = true;

    List<GameObject> Ennemies;



    private void Awake()
    {
        currentState = this;
    }

    void Start()
    {
        Ennemies = new List<GameObject>();

        for (int i = 0; i < ennemyAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Ennemy);
            obj.SetActive(false);
            Ennemies.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < Ennemies.Count; i++)
        {
            if (!Ennemies[i].activeInHierarchy)
            {
                return Ennemies[i];
            }
        }

        if (addOrNotToAdd)
        {
            GameObject obj = (GameObject)Instantiate(Ennemy);
            Ennemies.Add(obj);
            return obj;
        }

        return null;
    }

    private void EnnemyFire()
    {
        for (int i = 0; i < Ennemies.Count; i++)
        {
            if (!Ennemies[i].activeInHierarchy)
            {
                Ennemies[i].transform.position = transform.position;
                Ennemies[i].transform.rotation = transform.rotation;
                Ennemies[i].SetActive(true);
                break;
            }
        }
    }
}
