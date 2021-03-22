using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public bool pulando;
    public bool doublejump;
    private Rigidbody2D rig;
    private Animator anim;
    private CapsuleCollider2D coll;
    public static Player instance;
    private bool isBlowing;
    // Start is called before the first frame update

   
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Pula();
    }

    private void Move()
    {
        Vector3 movemente = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movemente * Time.deltaTime * speed;
        if (Input.GetAxis("Horizontal")>0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("walk", true);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("walk", true);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    private void Pula()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!pulando)
            {
                //rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                rig.velocity += Vector2.up * jumpforce;
                doublejump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doublejump)
                {
                    //rig.AddForce(new Vector2(0f, jumpforce * 0.8f), ForceMode2D.Impulse);
                    rig.velocity = Vector2.up * jumpforce * 0.8f;
                    doublejump = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Spike")
        {
            Morrer();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            pulando = false;
            anim.SetBool("jump", false);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            pulando = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if (pulando)
            {
                doublejump = false;
            }
        }
    }

    public void Morrer()
    {
        GameController.instance.ShowGameOver();
        anim.SetTrigger("Die");
        coll.enabled = false;
        speed = 0;
        rig.velocity = Vector2.up * 5f;
        Destroy(gameObject, 0.3f);
        Time.timeScale = 0.3f;
        AudioController.instance.songDieMusic();
    }
}
