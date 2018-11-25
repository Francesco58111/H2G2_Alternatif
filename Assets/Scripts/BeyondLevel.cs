using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyondLevel : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
    
}
