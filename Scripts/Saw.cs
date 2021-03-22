using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float movetime;
    private bool direction = true;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (direction) //se verdadeiro a serra vai a direita, se falso, para a esquerda
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= movetime)
        {
            direction = !direction;
            timer = 0f;
        }
    }
}
