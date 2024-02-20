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
}
