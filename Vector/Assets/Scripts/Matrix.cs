using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public float Angle;
    public Vector3[] ModelSpaceVertices;
    public Vector3 NewPosition = new Vector3();
    void Start()
    {
        MeshFilter MF =  GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.sharedMesh.vertices;
    }

    void Update()
    {
        // Add to Yaw Angle
        Angle += Time.deltaTime;

        //Define new array with correct size
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        // Create Rotation Matrix
        //Matrix4by4 RotateMatrix = new Matrix4by4(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1), Vector3.zero);

        // Create Rotation Matrix that rotate around a Roll
        Matrix4by4 RollMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(Angle), Mathf.Sin(Angle), 0),
            new Vector3(-Mathf.Sin(Angle), Mathf.Cos(Angle), 0),
            new Vector3(0, 0, 1),
            Vector3.zero);

        // Create Rotation Matrix that rotate around a Pitch
        Matrix4by4 PitchMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, Mathf.Cos(Angle), Mathf.Sin(Angle)),
            new Vector3(0, -Mathf.Sin(Angle), Mathf.Cos(Angle)),
            Vector3.zero);

        // Create Rotation Matrix that rotate around a Yaw
        Matrix4by4 YawMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(Angle), 0, -Mathf.Sin(Angle)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(Angle), 0, Mathf.Cos(Angle)),
            Vector3.zero);

        // Create Scaling Matrix (2x, y ,z)
        Matrix4by4 ScaleMatrix = new Matrix4by4(
            new Vector3(1, 0, 0) * 2.0f,
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            Vector3.zero);

        // Create Translate Matrix
        Matrix4by4 TranslationMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            new Vector3(NewPosition.x, NewPosition.y, NewPosition.z));
                
        Matrix4by4 RotationMatrix = YawMatrix * (PitchMatrix * RollMatrix);
        Matrix4by4 NewMatrix = TranslationMatrix * (RotationMatrix * ScaleMatrix);
        
        // Transform Each Vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            // Rotation
            //TransformedVertices[i] = RotateMatrix * ModelSpaceVertices[i];

            /*Vector3 RolledVertex = RollMatrix * ModelSpaceVertices[i];
            Vector3 PitchedVertex = PitchMatrix * RolledVertex;
            Vector3 YawedVertix = YawMatrix * PitchedVertex;
            TransformedVertices[i] = YawedVertix;*/

            // Scale
            //TransformedVertices[i] = ScaleMatrix * ModelSpaceVertices[i];

            // Transform
            /*Vector4 TransformVector4 = new Vector4(ModelSpaceVertices[i].x, ModelSpaceVertices[i].y, ModelSpaceVertices[i].z, 1);

            TransformedVertices[i] = TranslationMatrix * TransformVector4;*/

            // Combined
            TransformedVertices[i] = NewMatrix * ModelSpaceVertices[i];
        }

        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = TransformedVertices;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
