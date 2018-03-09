using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    private Rigidbody rigibody;
    [SerializeField]
    private float speed;
    
	// Use this for initialization
	void Start () {
        rigibody = this.GetComponent<Rigidbody>();
        rigibody.velocity = transform.forward * speed;

    }
	
}
