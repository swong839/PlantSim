using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudController : MonoBehaviour {
    
    Rigidbody rb;
    
    public int maxspeed;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        move();
	}

    private void move()
    {
        if (Input.GetAxis("Horizontal") == 0) {
            rb.velocity -= 20 * rb.velocity.normalized * Time.fixedDeltaTime;
        } else if (rb.velocity.magnitude < maxspeed) {
            rb.velocity += 20 * new Vector3(Input.GetAxis("Horizontal"), 0, 0).normalized * Time.fixedDeltaTime;
        }
    }
}
