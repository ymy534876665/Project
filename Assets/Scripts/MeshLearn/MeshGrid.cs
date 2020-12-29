using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class MeshGrid : MonoBehaviour {

	public int xSize, ySize;

	/// <summary>
	/// 顶点数组
	/// </summary>
	public Vector3[] Vertexes;


	private MeshFilter _meshFilter;
	void Awake()
	{
		//StartCoroutine(DrawVertexes());
		DrawVertexes();
	}

	void DrawVertexes()
	{
		Vertexes = new Vector3[(xSize + 1) * (ySize + 1)];
		Vector2[] uv = new Vector2[Vertexes.Length];
		for (int i = 0, y = 0; y <= ySize; y++)
		{
			for (int x = 0; x <= xSize; x++,i++)
			{
				Vertexes[i] = new Vector3(x, y);
				uv[i] = new Vector2((float)x/xSize,(float)y/ySize);
			}
		}
		_meshFilter = GetComponent<MeshFilter>();
		Mesh mesh = new Mesh();
		_meshFilter.mesh = mesh;
		mesh.name = "test mesh";
		mesh.vertices = Vertexes;
		mesh.uv = uv;
		//三角形
		int[] triangles = new int[xSize*6 * ySize];
		int t1 = 0;
		int v1 = 0;
		for (int y = 0; y < ySize; y++)
		{
			for (int x = 0; x < xSize; x++)
			{
				triangles[t1] = v1;
				triangles[t1 + 1] = triangles[t1 + 4] = xSize + v1 + 1;
				triangles[t1 + 2] = triangles[t1 + 3] = v1 + 1;
				triangles[t1 + 5] = xSize + v1 + 2;
				t1 += 6;
				v1++;
				
			}
			v1++;
		}
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		//int[] triangles = new int[6];
		//triangles[0] = 0;
		//triangles[1] = triangles[4] = xSize + 1;
		//triangles[2] = triangles[3] = 1;
		//triangles[5] = xSize + 2;


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
