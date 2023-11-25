using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] Vector2Int size;
    public void Generate()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = CreateVertices();
        mesh.triangles = CreateTriangles();

        mesh.RecalculateNormals();
        meshFilter.sharedMesh = mesh;

    }
    private Vector3[] CreateVertices()
    {
        Vector3[] vertices = new Vector3[(size.x + 1) * (size.y + 1)];

        for (int z = 0, i = 0; z < size.y; z++)
        {
            for (int x = 0; x < size.x; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }
        return vertices;
    }

    private int[] CreateTriangles()
    {
        int[] triangles = new int[size.x * size.y * 6];

        for (int z = 0, vert = 0, tris = 0; z < size.y; z++)
        {
            for (int x = 0; x < size.x; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + size.x + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + size.x + 1;
                triangles[tris + 5] = vert + size.x + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        return triangles;
    }

    private void Start()
    {
        Generate();
    }
}
