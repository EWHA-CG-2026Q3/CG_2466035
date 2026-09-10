using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomPyramidMesh : MonoBehaviour
{
    void Start()
    {
        // 밑면 4개 정점(y=0) + 꼭짓점 1개(위쪽)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0.5f, 1f, 0.5f),
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            1, 0, 4,
            2, 1, 4,
            3, 2, 4,
            0, 3, 4,
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}