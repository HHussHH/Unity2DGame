using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtelMover : MonoBehaviour
{
    private Animator animator;
  
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        animator.Play("IdelW");
    }



}
