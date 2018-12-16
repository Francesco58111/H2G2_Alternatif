using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    [Header("Mort du player")]
    public MeshRenderer playerGO;
    public ParticleSystem explosion;



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
            //FXManager.Instance.InitializePS(ps, playerGO.transform);
            //playerGO.SetActive(false);
            //GameManager.Instance.GameOver();
            StartCoroutine(Dying());
        }
    }
    

    /// <summary>
    /// Update de l'UI
    /// </summary>
    private void HealthBarUpdate()
    {
        healthBar.fillAmount = health / healthMax;
    }

    IEnumerator Dying()
    {
        var duration = explosion.main.duration;
        playerGO.enabled = false;
        explosion.Play();
        yield return new WaitForSeconds(duration);
        playerGO.gameObject.SetActive(false);
        GameManager.Instance.GameOver();
    }

}
