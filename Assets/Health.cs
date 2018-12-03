using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health = 10;
    [SerializeField]
    float healthMax = 10;
    public Image healthBar;

    public static Health Instance;


    public float healingSpeed;
    public float damages;

    void Awake()
    {
        Instance = this;
        
    }


    void Update()
    {
        CheckHealth();
        HealthBarUpdate();
    }

    public void LosingHealth()
    {
        health -= damages;
    }


    public void Healing()
    {
        if(health < healthMax)
        {
            health += Time.deltaTime * healingSpeed;
        }
        else
        {
            print("Health max reached");
        }
    }


    private void CheckHealth()
    {
        if (health < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void HealthBarUpdate()
    {
        healthBar.fillAmount = health / healthMax;
    }

}
