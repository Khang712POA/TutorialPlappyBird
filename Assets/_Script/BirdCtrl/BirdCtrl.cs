using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : MonoBehaviour
{
    public float boundForce;

    private Rigidbody2D rdBody2d;
    private Animator animator;

    private void Awake()
    {
        rdBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        BirdFly();
    }
    void BirdFly()
    {
        if(Input.GetMouseButtonUp(0)) {
            rdBody2d.velocity = new Vector2(rdBody2d.velocity.x, boundForce);   
        }
    }
}
