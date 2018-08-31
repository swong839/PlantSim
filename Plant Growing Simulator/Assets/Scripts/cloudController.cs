using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
    
    Rigidbody rb;
    
    public int maxspeed;


   private bool m_CanMove;

   private void OnEnable()
   {
      GameManager.GameOverEvent += SetCanMoveFalse;
   }

   private void OnDisable()
   {
      GameManager.GameOverEvent -= SetCanMoveFalse;
   }

   private void SetCanMoveFalse()
   {
      m_CanMove = false;
   }



   private void Awake()
   {
      m_CanMove = true;
   }

   void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
      if (m_CanMove)
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
