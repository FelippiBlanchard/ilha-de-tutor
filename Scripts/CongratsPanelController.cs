using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratsPanelController : MonoBehaviour
{
    public Image cherrie1;
    public Image notCherrie1;
    public Image cherrie2;
    public Image notCherrie2;
    public Image cherrie3;
    public Image notCherrie3;

    public static CongratsPanelController instance;

    private void Awake()
    {
        instance = this;
    }
    public void CongratsZero()
    {
        cherrie1.enabled = false;
        notCherrie1.enabled = true;

        cherrie2.enabled = false;
        notCherrie2.enabled = true;

        cherrie3.enabled = false;
        notCherrie3.enabled = true;
    }
    public void CongratsOne()
    {
        cherrie1.enabled = true;
        notCherrie1.enabled = false;
        
        cherrie2.enabled = false;
        notCherrie2.enabled = true;

        cherrie3.enabled = false;
        notCherrie3.enabled = true;
    }
    public void CongratsTwo()
    {
        cherrie1.enabled = true;
        notCherrie1.enabled = false;

        cherrie2.enabled = true;
        notCherrie2.enabled = false;

        cherrie3.enabled = false;
        notCherrie3.enabled = true;
    }
    public void CongratsThree()
    {
        cherrie1.enabled = true;
        notCherrie1.enabled = false;

        cherrie2.enabled = true;
        notCherrie2.enabled = false;

        cherrie3.enabled = true;
        notCherrie3.enabled = false;
    }
}
