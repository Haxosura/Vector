using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolate : MonoBehaviour
{
    public Vector3 ServerPos = new Vector3 (0,0,0);
    void Update()
    {
        transform.position = MathsLib.VectorLerp(transform.position, ServerPos, Time.deltaTime);
    }
}
