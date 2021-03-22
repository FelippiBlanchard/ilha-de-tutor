using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallin_plataform : MonoBehaviour
{
    public float fallintime;
    private TargetJoint2D target;
    private BoxCollider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallintime);
        }
        if (collision.gameObject.layer == 7 )
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
    void Falling()
    {
        target.enabled = false;
        collider.isTrigger = true;
    }
}
