using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletPooling : MonoBehaviour {

    public static EnnemyBulletPooling currentBullets;
    public GameObject pooledObject;
    public int pooledAmount = 10;
    public bool willGrow = true;

    List<GameObject> pooledObjectS;



    private void Awake()
    {
        currentBullets = this;
    }

    void Start()
    {
        pooledObjectS = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjectS.Add(obj);
        }
    }

    public GameObject GetPooledEnnemyBullets()
    {
        for (int i = 0; i < pooledObjectS.Count; i++)
        {
            if (!pooledObjectS[i].activeInHierarchy)
            {
                return pooledObjectS[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjectS.Add(obj);
            return obj;
        }

        return null;
    }

    private void EnnemyFire()
    {
        for (int i = 0; i < pooledObjectS.Count; i++)
        {
            if (!pooledObjectS[i].activeInHierarchy)
            {
                pooledObjectS[i].transform.position = transform.position;
                pooledObjectS[i].transform.rotation = transform.rotation;
                pooledObjectS[i].SetActive(true);
                break;
            }
        }
    }
}
