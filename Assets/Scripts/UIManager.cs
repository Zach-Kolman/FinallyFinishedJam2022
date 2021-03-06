using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject switchPanel;
    [SerializeField] private Text restartText;
    public bool isGameOver = false;
    public bool showSwitchText = false;

    // Start is called before the first frame update
    void Start()
    {
        //Disables panel if active
        switchPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    public void GameIsOver(bool seenByAI)
    {
        if(seenByAI)
        {
            GetComponent<AudioSource>().Play();
        }
        isGameOver = true;
    }

    public void ShowSwitchText()
    {
        showSwitchText = !showSwitchText;
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger game over manually and check with bool so it isn't called multiple times
        if (isGameOver)
        {
            //isGameOver = true;

            StartCoroutine(GameOverSequence());
        }

        //If game is over
        if (isGameOver)
        {
            //If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
        }

        if(showSwitchText)
        {
            switchPanel.SetActive(true);
        }
        else
        {
            switchPanel.SetActive(false);
        }
    }

    //controls game over canvas and there's a brief delay between main Game Over text and option to restart/quit text
    private IEnumerator GameOverSequence()
    {
        gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        restartText.gameObject.SetActive(true);
    }
}
