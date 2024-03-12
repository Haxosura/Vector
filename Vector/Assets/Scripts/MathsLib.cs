using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class MathsLib
{
    //Workshop 3

    public static float VectorToRadians(Vector2 V)
    {
        float rv = 0.0f;

        rv = Mathf.Atan(V.y / V.x);

        return rv;
    }

    public static Vector2 RandiansToVector(float Angle)
    {
        Vector2 rv = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));

        return rv;
    }

    public static MyVector RadianstoDegrees(MyVector Radians)
    {
        MyVector Degrees = new MyVector(0, 0, 0);

        Degrees.x = Radians.x * 180 / Mathf.PI;
        Degrees.y = Radians.y * 180 / Mathf.PI;
        Degrees.z = Radians.z * 180 / Mathf.PI;

        return Degrees;
    }

    public static MyVector DegreesToRadians(MyVector Degrees)
    {
        MyVector Radians = new MyVector(0, 0, 0);

        Radians.x = Degrees.x / (180 / Mathf.PI);
        Radians.y = Degrees.y / (180 / Mathf.PI);
        Radians.z = Degrees.z / (180 / Mathf.PI);

        return Radians;
    }

    public static MyVector EularAngleToDirection(MyVector EulerAngle)
    {
        MyVector rv = new MyVector(0, 0, 0);

        rv.z = Mathf.Cos(EulerAngle.y) * Mathf.Cos(-EulerAngle.x);
        rv.y = Mathf.Sin(-EulerAngle.x);
        rv.x = Mathf.Cos(-EulerAngle.x) * Mathf.Sin(EulerAngle.y);

        return rv;
    }

    public static MyVector VectorCrossProduct(MyVector A, MyVector B)
    {
        MyVector C = new MyVector(0, 0, 0);

        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }

    public static Vector3 VectorLerp(Vector3 A, Vector3 B, float T)
    {
        return A *(1.0f - T) + B * T;
    }
}

//Workshop 4

public class Matrix4by4
{
    public float[,] values;
    
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values[0,0] = column1.x;
        values[1,0] = column1.y;
        values[2,0] = column1.z;
        values[3,0] = column1.w;

        values[0,1] = column2.x;
        values[1,1] = column2.y;
        values[2,1] = column2.z;
        values[3,1] = column2.w;

        values[0,2] = column3.x;
        values[1,2] = column3.y;
        values[2,2] = column3.z;
        values[3,2] = column3.w;

        values[0,3] = column4.x;
        values[1,3] = column4.y;
        values[2,3] = column4.z;
        values[3,3] = column4.w;
    }

    public Matrix4by4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        values = new float[4,4];

        values[0,0] = column1.x;
        values[1,0] = column1.y;
        values[2,0] = column1.z;
        values[3, 0] = 0;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        values[0, 3] = column1.x;
        values[1, 3] = column1.y;
        values[2, 3] = column1.z;
        values[3, 3] = 1;
    }

    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new Vector4(1, 0, 0, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1));
        }
    }

    public static Vector4 operator *(Matrix4by4 lhs, Vector4 b)
    {
        return Vector4.zero;
    }
}