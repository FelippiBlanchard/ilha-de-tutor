using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalscore;
    public int maxScore;
    public Text scoreText;
    public Text finalScoreText;
    public GameObject gameOver;
    public GameObject optionsPanel;
    public GameObject congrats;
    public Player player;
    public bool optionsOpen;
    public bool activableEsc;

    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        if((SceneManager.GetActiveScene().name == "Menu") || (SceneManager.GetActiveScene().name == "Final"))
        {
            activableEsc = false;
        }
        else
        {
            activableEsc = true;
        }
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && activableEsc)
        {
            Options();
        }
    }
    public void UpdateScore()
    {
        scoreText.text = totalscore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        activableEsc = false;
    }
    public void Options()
    {
        if (!optionsOpen)
        {
            Time.timeScale = 0f;
            optionsPanel.SetActive(true);
            optionsOpen = true;
            AudioController.instance.backgroundMusic.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            optionsPanel.SetActive(false);
            optionsOpen = false;
            AudioController.instance.backgroundMusic.UnPause();
        }
    }
    public void PlayerDie()
    {
        Player.instance.Morrer();
    }
    public void RestartGame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
    public void ExitGame()
    {
        Application.Quit();

        /*
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("https://feblanchard.itch.io");

        */
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }    
    public void Congrats()
    {
        congrats.SetActive(true);
        Time.timeScale = 0f;
        finalScoreText.text = totalscore.ToString() + "/" + maxScore.ToString();
        activableEsc = false;

        if (totalscore < maxScore * 0.3f)
        {
            CongratsPanelController.instance.CongratsZero();
        }
        else
        {
            if ((totalscore >= maxScore * 0.3f)&& totalscore < maxScore * 0.7f)
            {
                CongratsPanelController.instance.CongratsOne();
            }
            else
            {
                if ((totalscore >= maxScore * 0.7f) && totalscore < maxScore)
                {
                    CongratsPanelController.instance.CongratsTwo();
                }
                else
                {
                    
                        CongratsPanelController.instance.CongratsThree();

                    
                }
            }
        }
    }
}
