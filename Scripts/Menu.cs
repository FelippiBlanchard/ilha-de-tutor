using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject showLevels;

    private void Start()
    {
        ShowsMenu();
    }
    public void ShowsLevels()
    {
        showLevels.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void ShowsMenu()
    {
        showLevels.SetActive(false);
        menuPanel.SetActive(true);
    }
}
