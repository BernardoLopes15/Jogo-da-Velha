using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject[] input;
	public Vector2Int matrixSize;

	public XorO_Piece X;
	public XorO_Piece O;

	int turnsCounter;
	public LayerMask mask;

	public XorO_Piece[,] XO_Pieces;

	// Start is called before the first frame update
	void Start()
	{
		XO_Pieces = new XorO_Piece[matrixSize.x, matrixSize.y];
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
			InstatiateXOs();

		WhoWins();
	}

	public void InstatiateXOs()
	{
		int count = 0;
		for (int i = 0; i < matrixSize.x; i++)
		{
			for (int j = 0; j < matrixSize.x; j++)
			{
				if (Physics.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward), out RaycastHit hitinfo, 100f) && hitinfo.collider.gameObject == input[count])
				{
					if (XO_Pieces[i, j] == null)
					{
						if (turnsCounter % 2 == 0)
						{
							XO_Pieces[i, j] = X;
							XO_Pieces[i, j].InstatiateXO(input[count].transform.position, Quaternion.identity);
						}
						else
						{
							XO_Pieces[i, j] = O;
							XO_Pieces[i, j].InstatiateXO(input[count].transform.position, Quaternion.identity);
						}
					}
				}
				count++;
			}
		}
		turnsCounter++;
	}

	public void WhoWins()
	{
	}
}
