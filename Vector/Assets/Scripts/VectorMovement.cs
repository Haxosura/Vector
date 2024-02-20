using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VectorMovement : MonoBehaviour
{
    MyVector Euler;
    MyVector EulerDirection;
    MyVector ForwardDirection;

    MyVector EulerUp;
    MyVector RightDirection;

    Vector3 EulerVector;

    public float Speed;

    // Update is called once per frame
    void Update()
    {

        Euler = new MyVector(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        EulerDirection = MathsLib.DegreesToRadians(Euler);
        ForwardDirection = MathsLib.EularAngleToDirection(EulerDirection);

        EulerUp = new MyVector(0, 1, 0);
        RightDirection = MathsLib.VectorCrossProduct(EulerUp, ForwardDirection);

        EulerVector = ForwardDirection.ToUnityVector();

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += EulerVector * (Time.deltaTime * Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= EulerVector * (Time.deltaTime * Speed);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.position += RightDirection.ToUnityVector() * (Time.deltaTime * Speed);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= RightDirection.ToUnityVector() * (Time.deltaTime * Speed);
        }
    }
}
