using System.Collections;
using System.Collections.Generic;
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

    public static MyVector VectorCrossProduct(MyVector A, MyVector B)
    {
        MyVector C = new MyVector(0, 0, 0);

        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }
}
