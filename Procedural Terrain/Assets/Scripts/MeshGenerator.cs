using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private int xSize;
    [SerializeField] private int zSize;


    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }

   void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //loop through the vertices and assign them to a grid
        for (int z = 0, index = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                vertices[index] = new Vector3(x, 0, z);
                index++;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        foreach (var vertex in vertices)
        {
            if (vertex != null)
            {
                Gizmos.DrawSphere(vertex, 0.1f);
            }
        }
    }
}
