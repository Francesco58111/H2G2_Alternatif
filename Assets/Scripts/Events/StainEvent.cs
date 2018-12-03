using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainEvent : MonoBehaviour
{

    public SpriteRenderer stainOpacity;
    public Animator stainAnimator;

    public Animator wipperAnim;


    public bool isThereAStain;
    public float currentAlpha;

    public static StainEvent Instance;




    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        //StainAppears();
    }

    public void StainAppears()
    {
        currentAlpha = 1;
        stainAnimator.gameObject.SetActive(true);
        stainAnimator.SetTrigger("Appears");
        isThereAStain = true;
        
    }

    
    void Update()
    {
        stainOpacity.color = new Color(1, 1, 1, currentAlpha);
    }


    public void Wip()
    {
        
        
        if (!wipperAnim.GetCurrentAnimatorStateInfo(0).IsName("Wipping"))
        {
            //wipperAnim.Play("Wipping");
            wipperAnim.SetTrigger("Wipping");

            if (currentAlpha > 0.01f)
            {
                currentAlpha -= 0.33f;
            }
            else
            {
                CleanVision();
            }
        }   
    }

    private void CleanVision()
    {
        currentAlpha = 0;
        stainAnimator.SetTrigger("Disappears");
        isThereAStain = false;
    }
}
