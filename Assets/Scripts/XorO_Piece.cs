using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XorO_Piece : MonoBehaviour
{
	public char XorO;
	public Vector2Int Position;

    public void InstatiateXO(Vector3 position, Quaternion rotation, char xOrO, Vector2Int matrixPosition)
	{
		Instantiate(GetComponent<SpriteRenderer>(), position, rotation);
	}
}