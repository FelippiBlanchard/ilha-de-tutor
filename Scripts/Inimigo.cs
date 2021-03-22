using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anima;
    private BoxCollider2D coll;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rig.velocity = new Vector2(speed, rig.velocity.y);  esse código ele vai travando no chão, o de baixo não




        Vector3 movemente = new Vector3(speed, 0f, 0f);
        transform.position += movemente * Time.deltaTime;

        //   IA encostar parede e virar
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            if (height > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                anima.SetTrigger("Die");
                speed = 0;
                coll.enabled = false;
                //rig.constraints = RigidbodyConstraints2D.FreezePositionY; congela no eixo y
                rig.velocity += Vector2.up * 5f;
                Destroy(gameObject, 0.5f);
            }
            else
            {
                GameController.instance.PlayerDie();
            }
        }

        if (collision.gameObject.layer == 6)
        { 
            

        }
    }
}
