using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public PlayerProperties playerProperties;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }



    public void AnimationUpdate()
    {
        
      

    }
}
