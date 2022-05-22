using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CypherOuterRing : MonoBehaviour
{
    public CypherOuterRing()
    {
        // This is a constructor.
    }
    public float speed = 5.0f; 
    private Vector3 targetPosition;
    private bool isMoving = false;
    void Update()
    {
        if (Input.GetMouseButton(0) & Input.GetKey(KeyCode.LeftShift))
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            Move();
        }
    }
    void SetTargetPosition() 
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }
    void Move() 
    {   
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - transform.position);
       
            isMoving = false;
    }
}
