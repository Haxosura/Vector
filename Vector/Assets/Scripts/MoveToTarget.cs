using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveToTarget : MonoBehaviour
{
    public GameObject Target;

    public MyVector Pursuer; // Owner
    public MyVector Evader; // Target

    public MyVector Gap;
    public MyVector NormalizeGap;

    public Vector3 MoveToVector;

    public float Speed = 20.0f;

    private bool Stopped = false;
    public float Range = 20;

    // Update is called once per frame
    void Update()
    {
        FindObject();
        MoveToEvader();

        /*if (!Stopped)
        {
            FindObject();
            CheckDistancesRange();
            //Debug.Log("Stopped");
        }
        else
        {
            
            CheckDistancesRange();
            //Debug.Log("Stopped");
        }*/
        
    }

    public void FindObject()
    {
        Target = GameObject.Find("Sphere");
        Evader = new MyVector(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        //Debug.Log("EvaderPosition: " + "X: " + Evader.x + ", Y:  " + Evader.y + ", Z: " + Evader.z);

        Pursuer = new MyVector(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //Debug.Log("PursuerPosition: " + "X: " + Pursuer.x + ", Y:  " + Pursuer.y + ", Z: " + Pursuer.z);
    }

    public void MoveToEvader()
    {
        Gap = MyVector.SubtractVector(Evader, Pursuer);
        

        Debug.Log(Gap.GetMegg());

        if (Gap.GetMegg() >= Range)
        {   
            Gap = Gap.Normalize();
            MoveToVector = Gap.ToUnityVector();
            this.transform.position += MoveToVector * Time.deltaTime * Speed;
        }

        

        //this.transform.position = MoveToVector;
        //Debug.Log("Gap: " + "X: " + Gap.x + ", Y:  " + Gap.y + ", Z: " + Gap.z);
        //Debug.Log("Moving To Evaders");
    }

    public void CheckDistancesRange()
    {
        if (Gap.GetMegg() <= Range)
        {
            Stopped = true;
        }
        else
        {
            Stopped = false;
        }
    }

}
