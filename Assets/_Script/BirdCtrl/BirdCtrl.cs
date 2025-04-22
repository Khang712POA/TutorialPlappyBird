using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : MonoBehaviour
{
    public float boundForce;

    private Rigidbody2D rdBody2d;
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, dieClip;

    private void Awake()
    {
        rdBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        _BirdFly();
    }
    void _BirdFly()
    {
        if(Input.GetMouseButtonUp(0)) {
            rdBody2d.velocity = new Vector2(rdBody2d.velocity.x, boundForce);
            audioSource.PlayOneShot(pingClip);
        }

        if(rdBody2d.velocity.y >0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 90, rdBody2d.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }else if(rdBody2d.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -rdBody2d.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
