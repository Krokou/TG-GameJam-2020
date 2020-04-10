using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCredits : MonoBehaviour
{
    public Animator creditsAnimator;

    private void Awake()
    {
        creditsAnimator.SetInteger("animstate", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //creditsAnimator.Play("Credit_anim", 0, 1);
        creditsAnimator.SetInteger("animstate", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
