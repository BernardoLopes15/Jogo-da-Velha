using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XorO_Piece : MonoBehaviour
{
	public char XorO;

    public void InstatiateXO(Vector3 position, Quaternion rotation)
	{
		Instantiate(GetComponent<SpriteRenderer>(), position, rotation);
	}
}