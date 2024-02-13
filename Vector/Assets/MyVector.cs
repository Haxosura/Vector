using Palmmedia.ReportGenerator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyVector
{
    public float x, y, z;

    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyVector AddVector(MyVector a, MyVector b)
    {
        MyVector rv = new MyVector(0, 0, 0);

        rv.x = a.x + b.x;
        rv.y = a.y + b.y;
        rv.z = a.z + b.z;

        //Debug.Log(rv);

        return rv;
    }

    public static MyVector SubtractVector(MyVector a, MyVector b)
    {
        MyVector rv = new MyVector(0, 0, 0);

        rv.x = a.x - b.x;
        rv.y = a.y - b.y;
        rv.z = a.z - b.z;

        //Debug.Log(rv);

        return rv;
    }

    public float GetMegg()
    {
        float rv;

        rv = MathF.Sqrt(x * x + y * y + z * z);

        //Debug.Log(rv);

        return rv;
    }

    public Vector3 ToUnityVector()
    {
        Vector3 rv = new Vector3(x, y, z);

        //rv.x = x;
        //rv.y = y;
        //rv.z = z;

        return rv;
    }

    public static MyVector Scalar(MyVector vector, float scalar)
    {
        MyVector rv = new MyVector(0, 0, 0);

        vector.x = vector.x * scalar;
        vector.y = vector.y * scalar;
        vector.z = vector.z * scalar;

        return rv;
    }

    public static MyVector Divisor(MyVector vector, float divisor)
    {
        MyVector rv = new MyVector(0, 0, 0);

        rv.x = vector.x / divisor;
        rv.y = vector.y / divisor;
        rv.z = vector.z / divisor;

        return rv;
    }

    public MyVector Normalize()
    {
        MyVector rv = new MyVector(0, 0, 0);
                
        rv = Divisor(this, GetMegg());

        return rv;
    }

    public float GetMaggSq()
    {
        float rv;

        rv = x * x + y * y + z * z;

        //Debug.Log(rv);

        return rv;
    }
}