using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Next_Level : MonoBehaviour

{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(lvlname);
            GameController.instance.Congrats();
            AudioController.instance.songCongrats();
        }

    }
}
