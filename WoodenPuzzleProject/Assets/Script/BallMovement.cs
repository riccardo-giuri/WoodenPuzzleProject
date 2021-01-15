using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private bool WantFlatInput = true;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Acceleration = Input.acceleration;

        if(WantFlatInput == true)
        {
            Acceleration = Quaternion.Euler(90, 0, 0) * Acceleration * speed;
        }

        rb.AddForce(new Vector3(Input.acceleration.x, 0f, Input.acceleration.y) * speed);

    }
}
