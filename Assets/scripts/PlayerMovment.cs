using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    //to control the Shield Power up
    public  bool _isInvincible = false;
    public GameObject avoid;

    //public GameObject PsSpeed;
    //public GameObject PsMagnet;
    //public GameObject PsShield;

    private Scores scores;
    public static float speed=10;
    public static float addspeed = 3f;
    public static bool Pause=false;
    public static float  timer = 0;
    public TMP_Text SpeedText;
    public Land land;
    private Rigidbody controller;
    private Vector3 moveVector;

    // Use this for initialization
    void Start()
    {
        print("shield " + _isInvincible);
        transform.eulerAngles = Vector3.zero;
        controller = GetComponent<Rigidbody>();    //start with calling the rigibody
        if (scores == null) scores = GameObject.FindObjectOfType<Scores>();
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

    public void _Jump()   //when the player swipes Up
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
    }

    private void Update()
    {
        if(Pause==true) {}
        else   //if it is not paused
        {
            timer += Time.deltaTime;

            if (timer >= 15)
            {
                timer = 0;
                speed += addspeed;  //Add more speed
                Scores.PointPerSeconds += 1;  //add the score
            }
        }

        if(_isInvincible)
            avoid.GetComponent<BoxCollider>().enabled = false;
        else
            avoid.GetComponent<BoxCollider>().enabled = true;

    }


    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Die") && _isInvincible)
        {
            print("saved");
            
            return;
        }
        else if(col.gameObject.CompareTag("Die") && _isInvincible==false)
        {
            
            print("not saved");
            Scores.GoldAmount += Scores.GoldCount;
            Scores.incresScore = false;   // stop increasing the score
            speed = 10;
            SceneManager.LoadScene(3);
        }
        
    }


    public void FixedUpdate()
    {
        if (Pause == true) {}
        else
        {
       transform.position += transform.forward * speed * Time.deltaTime;   //make the player keep going forward   
        transform.Translate(Input.acceleration.x, 0, 0);//allow the player to slide left and right when the phone is rotated
        SpeedText.text = ("SPEED: ") + speed;
        }
    }
}
