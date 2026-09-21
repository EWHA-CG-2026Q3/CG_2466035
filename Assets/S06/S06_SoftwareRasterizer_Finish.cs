using UnityEngine;

public class S06_SoftwareRasterizer_Finish : MonoBehaviour
{
    [SerializeField] private Vector2 vertexA = new Vector2(128, 200);
    [SerializeField] private Vector2 vertexB = new Vector2(60, 60);
    [SerializeField] private Vector2 vertexC = new Vector2(200, 60);
    [SerializeField] private Color fillColor = new Color(1f, 0.6f, 0.2f, 1f);
    [SerializeField] private Color backgroundColor = new Color(0f, 0f, 0f, 1f);

    [SerializeField] private int canvasWidth = 256;
    [SerializeField] private int canvasHeight = 256;

    private Material lineMaterial;

    void CreateMaterialIfNeeded()
    {
        if (lineMaterial != null) return;

        Shader shader = Shader.Find("Hidden/Internal-Colored");
        lineMaterial = new Material(shader);
        lineMaterial.hideFlags = HideFlags.HideAndDontSave;

        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        lineMaterial.SetInt("_ZWrite", 0);
    }

    void OnRenderObject()
    {
        CreateMaterialIfNeeded();
        lineMaterial.SetPass(0);

        GL.PushMatrix();

        
        GL.LoadPixelMatrix(0, canvasWidth, 0, canvasHeight);

        
        GL.Begin(GL.QUADS);
        GL.Color(backgroundColor);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(canvasWidth, 0, 0);
        GL.Vertex3(canvasWidth, canvasHeight, 0);
        GL.Vertex3(0, canvasHeight, 0);
        GL.End();

        
        GL.Begin(GL.TRIANGLES);
        GL.Color(fillColor);
        GL.Vertex3(vertexA.x, vertexA.y, 0);
        GL.Vertex3(vertexB.x, vertexB.y, 0);
        GL.Vertex3(vertexC.x, vertexC.y, 0);
        GL.End();

        GL.PopMatrix();
    }
}