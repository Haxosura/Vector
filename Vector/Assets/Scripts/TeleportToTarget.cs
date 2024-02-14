using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToTarget : MonoBehaviour
{
    public GameObject Sphere;

    public MyVector TargetPosition;
    public MyVector OwnerPosition;

    public MyVector SubLocation;
    public MyVector NewLocation;

    public Vector3 MoveToVector;


    // Start is called before the first frame update
    void Start()
    {
        //FindObject();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToObject();
    }

    public void FindObject()
    {
        Sphere = GameObject.Find("Sphere");
        TargetPosition = new MyVector(Sphere.transform.position.x, Sphere.transform.position.y, Sphere.transform.position.z);
        Debug.Log("TargetPosition: " + "X: " + TargetPosition.x + ", Y:  " + TargetPosition.y + ", Z: " + TargetPosition.z);

        OwnerPosition = new MyVector(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Debug.Log("OwnerPosition: " + "X: " + OwnerPosition.x + ", Y:  " + OwnerPosition.y + ", Z: " + OwnerPosition.z);
    }

    public void MoveLocation()
    {
        SubLocation = MyVector.SubtractVector(TargetPosition, OwnerPosition);
        NewLocation = MyVector.AddVector(SubLocation, OwnerPosition);

        MoveToVector = NewLocation.ToUnityVector();

        this.transform.position = MoveToVector;
    }

    public void MoveToObject()
    {
       if(Input.GetKeyDown("e"))
        {
            FindObject();
            MoveLocation();
        }
    }

}