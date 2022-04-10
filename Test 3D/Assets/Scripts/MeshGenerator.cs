using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh(mesh);

    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        int i = 0;
        for (int z = 0; z < (zSize + 1); z++)
        {
            for (int x = 0; x < (xSize + 1); x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f; // The multiplying at the end makes it more clear, and the multiplying the x and z by a smaller number makes it smoother.

                vertices[i] = new Vector3(x, y, z);
                i += 1;
            }

        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++) // vert is so that we can make sure it gets each pair of triangles one by one. I'm unsure of why it is called vert as it is a horizontal count, but we'll take it.
                                            // tris is updated by 6 every time so that the next 6 points we turn into triangles are 6 new points, not the old ones.
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert += 1;
                tris += 6;
            }

            vert += 1;

        }





    }

    void UpdateMesh(Mesh mesh)
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

}
