using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float SprintSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        float Speed = Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : MoveSpeed;

        transform.position += MoveDirection * Speed * Time.deltaTime;
    }
}
