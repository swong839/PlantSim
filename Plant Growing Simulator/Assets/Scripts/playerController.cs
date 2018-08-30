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
        if (Input.GetAxis("Horizontal") == 0) {
            rb.velocity -= 0.25f * rb.velocity.normalized;
        } else if (rb.velocity.magnitude < maxspeed) {
            rb.velocity += 0.25f * new Vector3(Input.GetAxis("Horizontal"), 0, 0).normalized;
        }
    }
}
