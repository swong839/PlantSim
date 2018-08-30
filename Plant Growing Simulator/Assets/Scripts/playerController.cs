using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    
    Rigidbody rb;
    
    public int maxspeed;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        move();
	}

    private void move()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0).normalized * maxspeed;
        rb.velocity += 0.05f * (inputVector - rb.velocity);
    }
}
