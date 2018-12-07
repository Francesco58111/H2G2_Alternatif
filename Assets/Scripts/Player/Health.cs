using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Set up de la vie")]
    public float health = 10;
    [SerializeField]
    float healthMax = 10;
    public Image healthBar;
    

    public static Health Instance;

    [Header("Update de la vie")]
    public float healingSpeed;
    public float damageTaken;
    public bool isInvisible;

    [Header("Récupération du GameObject player")]
    public GameObject playerGO;



    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        CheckHealth();
        HealthBarUpdate();

        /*
        if (Input.GetKeyDown(KeyCode.W))
            LosingHealth();
            */
    }

    /// <summary>
    /// Inflige des dégâts
    /// </summary>
    public void LosingHealth()
    {
        if(!isInvisible)
            health -= damageTaken;
    }


    /// <summary>
    /// Guérisson
    /// </summary>
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

    /// <summary>
    /// Check l'état de la vie
    /// </summary>
    private void CheckHealth()
    {
        if (health < 0)
        {
            playerGO.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }

    /// <summary>
    /// Update de l'UI
    /// </summary>
    private void HealthBarUpdate()
    {
        healthBar.fillAmount = health / healthMax;
    }

}
