using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;

    public GameObject WinnerX;
    public GameObject WinnerO;
    public GameObject Draw;

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
            SceneManager.LoadScene(0);
		}
    }

    public void GameOverOperations()
	{
        WinnerScreen();
        gameOver = true;
	}

    public void WinnerScreen()
	{
        gameOverScreen.SetActive(true);

        if (Player.Winner == 'X')
		{
            WinnerX.SetActive(true);
		}
        else if(Player.Winner == 'O')
		{
            WinnerO.SetActive(true);
        }
		else
		{
            Draw.SetActive(true);
        }
	}
}
