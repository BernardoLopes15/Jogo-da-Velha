using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] input;
    public Vector2Int matrixSize;

    public XO X;
    public XO O;

    int turnsCounter;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
            int count = 0;
            for (int i = 0; i < matrixSize.x; i++)
            {
                for (int j = 0; j < matrixSize.x; j++)
                {
                    if (Physics.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward), out RaycastHit hitinfo, 100f) && hitinfo.collider.gameObject == input[count])
					{
                        if(turnsCounter % 2 == 0)
						{
                            Instantiate(X, input[count].transform.position, Quaternion.identity);
                        }
						else
						{
                            Instantiate(O, input[count].transform.position, Quaternion.identity);
                        }
					}
                    count++;
                }
            }
            turnsCounter++;
        }
    }
}
