using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    //Positions and speed
    public Transform player;
    public Vector3 offSet ;
    public float smoothSpeed = 0.5f;

 
     public void FixedUpdate()
      {
        
        Vector3 desiredPosition = player.transform.TransformPoint(offSet);  //where the camera should be 
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  //change position from old one to new one and rotate with player
        transform.position = smoothPosition;  //make  a smooth change
        transform.LookAt(player);   //the camera should be looking at the player as a target
      }


    
}