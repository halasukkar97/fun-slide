using UnityEngine;
using System.Collections;


public class swipeTest : MonoBehaviour {

    public Land land;
    public GameObject Player;
    public GameObject Water;
    
    public float maxTime;
    public float minSwipeDist;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDistance;
    float swipeTime;

    bool inputIsEnabled = true;
    bool JumpInputIsEnabled = true;

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


    //stop the screen swipe fpr one sec after the player swipes
    IEnumerator Left()
    {
        print("Left");
        inputIsEnabled = false;
        yield return new WaitForSeconds(0.2f);
        inputIsEnabled = true;
    }
    IEnumerator Right()
    {
        print("right");
        inputIsEnabled = false;
        yield return new WaitForSeconds(0.2f);
        inputIsEnabled = true;
    }
    IEnumerator Up()
    {
        print("up");
        JumpInputIsEnabled = false;
        yield return new WaitForSeconds(2.5f);
        JumpInputIsEnabled = true;
    }


    void Swipe()  //mesure the swipe to know in which direction the swipe was made
    {
        Vector2 distance = endPos - startPos;
        if (inputIsEnabled)   //if the user is allowed to swipe
        {
            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {

                //right
                if (distance.x > 0 && land.rotate == true)
                {
                    //rotate the player right an stop the swipe 
                    Player.GetComponent<PlayerMovment>()._moveRight();
                    StartCoroutine("Right");

                }
                //left
                else if (distance.x < 0 && land.rotate == true)
                {
                    //rotate the player Left an stop the swipe 
                    Player.GetComponent<PlayerMovment>()._moveLeft();
                    StartCoroutine("Left");

                }


            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if(JumpInputIsEnabled)  //if allowed to jump jump
            { 

            //up
            if (distance.y > 0)
            {
                //make the player Jump an stop the swipe 
                Player.GetComponent<PlayerMovment>()._Jump();
                StartCoroutine("Up");
            }


            //down
            else if (distance.y < 0) { }
            // Debug.Log("down");

        }
        }
    }
}
