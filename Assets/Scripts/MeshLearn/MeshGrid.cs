using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class MeshGrid : MonoBehaviour {

	public int xSize, ySize;


	public Vector3[] Vertexes;
	void Awake()
	{
		StartCoroutine(DrawVertexes());
		//DrawVertexes();
	}

	IEnumerator DrawVertexes()
	{
		Vertexes = new Vector3[(xSize + 1) * (ySize + 1)];
		for (int i = 0, x = 0; x <= xSize; x++)
		{
			for (int y = 0; y <= ySize; y++,i++)
			{
				Vertexes[i] = new Vector3(x, y);
				yield return new WaitForSeconds(0.05f);
			}
		}
	}
	void OnDrawGizmos()
	{
		if (Vertexes == null)
		{
			return;
		}
		for (int i = 0; i < Vertexes.Length; i++)
		{
			Gizmos.color = Color.black;
			Gizmos.DrawSphere(Vertexes[i],0.1f);
		}
	}
}
