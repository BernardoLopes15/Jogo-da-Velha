using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;

    public GameObject WinnerX;
    public GameObject WinnerO;
    public GameObject Draw;

    public GameObject WinnerScore;
    public Text XScore;
    public Text OScore;

    bool gameOver;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Player.OnGameOver += GameOverOperations;
    }

    // Update is called once per frame
    void Update()
    {
		if (gameOver && Input.GetKeyDown(KeyCode.Mouse0))
		{
            gameOver = false;
            WinnerScreen(false);
            WinnerScoreController();

            Player.ResetDeparture();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
            SceneManager.LoadScene(0);
        }
    }

    public void GameOverOperations()
	{
        WinnerScreen(true);
        gameOver = true;
	}

    public void WinnerScreen(bool isActive)
	{
        WinnerScore.SetActive(!isActive);
        gameOverScreen.SetActive(isActive);

        if (Player.Winner == 'X')
		{
            WinnerX.SetActive(isActive);
		}
        else if(Player.Winner == 'O')
		{
            WinnerO.SetActive(isActive);
        }
		else
		{
            Draw.SetActive(isActive);
        }
	}

    public void WinnerScoreController()
	{
        if(Player.Winner == 'X')
		{
            XScore.text = (int.Parse(XScore.text) + 1).ToString();
		}
		else
		{
            OScore.text = (int.Parse(OScore.text) + 1).ToString();
        }
	}
}
