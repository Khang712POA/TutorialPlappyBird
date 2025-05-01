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

    private bool isAlive; // default false
    private bool didFlap;

    public float flag = 0;
    public static BirdCtrl instace;
    private GameObject SpanwerPipe;
    private void Awake()
    {
        isAlive = true;
        rdBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _MakeInstance();

        SpanwerPipe = GameObject.Find("SpawnerPipe");
    }
    void Update()
    {
        _BirdFly();
    }
    void _MakeInstance()
    {
        if(instace == null)
        {
            instace = this;
        }
    }    
    void _BirdFly()
    {
        if(isAlive)
        {
            if(didFlap)
            {
                didFlap = false;
                rdBody2d.velocity = new Vector2(rdBody2d.velocity.x, boundForce);
                audioSource.PlayOneShot(flyClip);
            }
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
    public void Flap()
    {
        didFlap = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PipeHolder")
        {
            audioSource.PlayOneShot(pingClip);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            flag = 1;
            if(isAlive)
            {
                isAlive = false;
                audioSource.PlayOneShot(dieClip);
                animator.SetTrigger("Die");
                Destroy(SpanwerPipe);
            }    
        }
    }
}
