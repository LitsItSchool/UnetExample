using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rigidbody;
    public Transform tower;
    public float maxSpeed;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (vertical != 0)
        {
            rigidbody.AddForce(transform.forward * vertical * 30, ForceMode.Force);
        }
        if (horizontal != 0)
        {
            //rigidbody.AddTorque(Vector3.up * horizontal * 5);
            transform.Rotate(Vector3.up, horizontal * 5);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            tower.Rotate(Vector3.up, -1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            tower.Rotate(Vector3.up, 1);

        }
    }
}
