using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public static float speed=10;
    public Land land;
    private Rigidbody controller;
    private Vector3 moveVector;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<Rigidbody>();    //start with calling the rigibody

    }

    public void _moveLeft()    //When the player swipes left
    {
        transform.Rotate(0, -90, 0);   //rotate the player 90 to left
        GetComponent<Rigidbody>().velocity = Vector3.zero;  //set the body velocity to 0
    }

    public void _moveRight()    //when the player swipes right
    {
        transform.Rotate(0, 90, 0);   // rotate the player 90 to Right
        GetComponent<Rigidbody>().velocity = Vector3.zero;  //set the body velocity to 0
    }

    private void FixedUpdate()
    {
      
        transform.position += transform.forward* speed * Time.deltaTime;   //make the player keep going forward 


    }
}
