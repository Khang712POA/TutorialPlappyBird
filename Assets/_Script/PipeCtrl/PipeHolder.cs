using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        _PipeMovent();

        if(BirdCtrl.instace != null)
        {
            if(BirdCtrl.instace.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
    }
    private void _PipeMovent()
    {
        Vector3 temp = transform.position;
        temp.x -= speed* Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
