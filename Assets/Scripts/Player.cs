using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player : MonoBehaviour
{
	public event Action OnGameOver;

	public GameObject[] input;
	public int matrixSize;

	public XorO_Piece X;
	public XorO_Piece O;

	int turnsCounter;
	public LayerMask mask;

	public XorO_Piece[,] XO_Pieces;
	public char Winner;

	public Vector2Int TurnPiecePosition;

	// Start is called before the first frame update
	void Start()
	{
		XO_Pieces = new XorO_Piece[matrixSize, matrixSize];
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			InstatiateXOs();
			if (GameIsOver() && OnGameOver != null)
			{
				OnGameOver();
			}
		}
	}

	public void InstatiateXOs()
	{
		int count = 0;
		for (int i = 0; i < matrixSize; i++)
		{
			for (int j = 0; j < matrixSize; j++)
			{
				RaycastOperations(i, j, count);
				count++;
			}
		}
		turnsCounter++;
	}

	public void RaycastOperations(int i, int j, int count)
	{

		if (Physics.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward), out RaycastHit hitinfo, 100f) && hitinfo.collider.gameObject == input[count])
		{
			if (XO_Pieces[i, j] == null)
			{
				if (turnsCounter % 2 == 0)
				{
					XO_Pieces[i, j] = X;
					XO_Pieces[i, j].InstatiateXO(input[count].transform.position, Quaternion.identity, 'X', new Vector2Int(i, j));

				}
				else
				{
					XO_Pieces[i, j] = O;
					XO_Pieces[i, j].InstatiateXO(input[count].transform.position, Quaternion.identity, 'O', new Vector2Int(i, j));
				}
				WhoWins(XO_Pieces[i, j].XorO, new Vector2Int(i, j));
			}
		}

	}

	public void WhoWins(char xorO, Vector2Int position)
	{
		int sum;

		//Vertical Analysis

		sum = 0;

		for (int i = 0; i < matrixSize; i++)
		{
			XorO_Piece analysePiece = XO_Pieces[i, position.y];
			if (analysePiece != null)
			{
				if (analysePiece.XorO == xorO)
				{
					sum += 1;
				}
			}
		}

		if (sum == matrixSize)
		{
			Winner = xorO;
			return;
		}

		//Horizontal Analysis

		sum = 0;

		for (int i = 0; i < matrixSize; i++)
		{
			XorO_Piece analysePiece = XO_Pieces[position.x, i];
			if (analysePiece != null)
			{
				if (analysePiece.XorO == xorO)
				{
					sum += 1;
				}
			}
		}

		if (sum == matrixSize)
		{
			Winner = xorO;
			return;
		}

		//Left to right diagonal analysis

		sum = 0;

		for (int i = 0; i < matrixSize; i++)
		{
			XorO_Piece analysePiece = XO_Pieces[i, i];
			if (analysePiece != null)
			{
				if (analysePiece.XorO == xorO)
				{
					sum += 1;
				}
			}
		}

		if (sum == matrixSize)
		{
			Winner = xorO;
			return;
		}

		//Right to left diagonal analysis

		sum = 0;

		for (int i = 0; i < matrixSize; i++)
		{
			XorO_Piece analysePiece = XO_Pieces[i, (matrixSize - 1) - i];
			if (analysePiece != null)
			{
				if (analysePiece.XorO == xorO)
				{
					sum += 1;
				}
			}
		}

		if (sum == matrixSize)
		{
			Winner = xorO;
			return;
		}
	}

	public bool GameIsOver()
	{
		int matrixSizeSquared = Mathf.RoundToInt(Mathf.Pow(matrixSize, 2));

		int count = 0;
		foreach(XorO_Piece p in XO_Pieces)
		{
			if(p != null)
			{
				count++;
			}
		}

		if(count == matrixSizeSquared || Winner == 'X' || Winner == 'O')
		{
			return true;
		}
		return false;
	}
}
