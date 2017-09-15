using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour {

	[SerializeField]private GameObject tile;
	void Start()
	{
		for(int i = 0;i<16;i++)
		{
			for(int j = 0;j<16;j++)
			{
				Instantiate(tile,new Vector3(i, j, 0),Quaternion.identity);
			}
		}
	}
}