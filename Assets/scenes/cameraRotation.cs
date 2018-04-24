using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    //Positions and speed
    public Transform player;
    public Vector3 offSet;
    public float smoothSpeed = 0.5f;
  

    //animations variabels
    private float transition = 0.0f;
    private float animationDuaration = 3.0f;
    private Vector3 animationOffSet = new Vector3(0,5, 7);


    public void FixedUpdate()
    {
        //this is to follow the player everywhere
        if (transition > 1)
        {
            Vector3 desiredPosition = player.transform.TransformPoint(offSet);  //where the camera should be 
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  //change position from old one to new one and rotate with player
            transform.position = smoothPosition;  //make  a smooth change
            transform.LookAt(player);   //the camera should be looking at the player as a target }
        }


        //this is the animation in the start of the game
        if (transition < 1)
        {
            Vector3 desiredPosition = player.transform.TransformPoint(offSet);
            transform.position = Vector3.Lerp(desiredPosition + animationOffSet, desiredPosition, transition);
            transition += Time.deltaTime * 1 / animationDuaration;
            transform.LookAt(player.position);
        }

    }
}