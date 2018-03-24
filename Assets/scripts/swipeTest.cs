using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeTest : MonoBehaviour {

    public Land land;
    public GameObject Player;
    
    public float maxTime;
    public float minSwipeDist;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDistance;
    float swipeTime;

 
    // Update is called once per frame
    void Update () {

        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            //calculate how long the user swiped 
            if (touch.phase==TouchPhase.Began) 
            {
                startTime = Time.time;
                startPos = touch.position;

            }
            else if(touch.phase == TouchPhase.Ended )
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                //if the swipe time is good then swipe
                if(swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    Swipe();
                }
            }
        }

    }
    void Swipe()  //mesure the swipe to know in which direction the swipe was made
    {
        Vector2 distance = endPos - startPos;
        if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y ))
        {
            Debug.Log("horizontal");

            //right
            if (distance.x > 0 && land.rotate==true)
            {
                Player.GetComponent<PlayerMovment>()._moveRight();
                
            }
            //left
            else if (distance.x < 0 && land.rotate == true)
            {
                Player.GetComponent<PlayerMovment>()._moveLeft();
                
            }
               

        }
        else if(Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            Debug.Log("vertical");

            //up
            if (distance.y > 0)
                Player.GetComponent<PlayerMovment>()._Jump();

            //down
            else if (distance.y < 0)
                Debug.Log("down");

        }
    }
}
