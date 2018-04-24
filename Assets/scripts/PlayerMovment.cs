using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerMovment : MonoBehaviour
{
    //to control the Shield Power up
    public static bool _isInvincible = false;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;

    //control the plyer movement
    private Scores scores;
    public static float speed=15;
    public static float addspeed = 3f;
    public static bool Pause=false;
    public static float  timer = 0;
    public Land land;
    private Rigidbody controller;
    private Vector3 moveVector;

  

    // Use this for initialization
    void Start()
    {

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
        GetComponent<Rigidbody>().velocity=new Vector3(0,10, 0);

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
                Scores.PointPerSeconds += 2;  //add the score
            }
        }


        //temp for me to control the game from a PC
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _moveLeft();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _moveRight();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _Jump();
           
        }
            
        
    }


    void OnCollisionEnter(Collision col)
    {
        //control the power ups 
        if (col.gameObject.CompareTag("Magnet"))
        {
            StartCoroutine("_Magnet");
        }
       if (col.gameObject.CompareTag("Shield"))
        {
            StartCoroutine("_Shield");
        }
         if (col.gameObject.CompareTag("Speed"))
        {
            StartCoroutine("_Speed");
        }
        if (col.gameObject.CompareTag("Die") && _isInvincible==true)
        {
            return;
        }
        if(col.gameObject.CompareTag("Die") && _isInvincible==false)
        {
            Scores.GoldAmount += Scores.GoldCount;
            Scores.incresScore = false;   // stop increasing the score
            speed = 15; 
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
        }
    }


    IEnumerator _Magnet()
    {
        
        FindObjectOfType<AudioManager>().PlayEffects("PowerUp"); //playe the sound
        Destroy(GameObject.FindWithTag("Magnet"));  //delete the powerup prefab
        transform.GetChild(4).gameObject.SetActive(true);
        //ativate the magnetfield  and the particle around the player
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(Shop.MagnetShow); //wait
        //diactivate the magnet fild and the particles
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        Cube1.GetComponent<BoxCollider>().enabled = true;
        Cube2.GetComponent<BoxCollider>().enabled = true;
        Cube3.GetComponent<BoxCollider>().enabled = true;

    }

    IEnumerator _Shield()
    {

        FindObjectOfType<AudioManager>().PlayEffects("PowerUp"); //playe the sound
        Destroy(GameObject.FindWithTag("Shield")); //delete the powerup prefab
        _isInvincible = true;  //make it invincible
        //diactivate the collider of the iceCubes
        Cube1.GetComponent<BoxCollider>().enabled = false;
        Cube2.GetComponent<BoxCollider>().enabled = false;
        Cube3.GetComponent<BoxCollider>().enabled = false;
        //add a particle around the player
        transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(Shop.ShieldShow);   //after the show time is done
        _isInvincible = false; //make it vincibile
        //activate the collider of the iceCubes
        Cube1.GetComponent<BoxCollider>().enabled = true;
        Cube2.GetComponent<BoxCollider>().enabled = true;
        Cube3.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(2).gameObject.SetActive(false);  //remove the particle around the player

    }

    IEnumerator _Speed()
    {
        FindObjectOfType<AudioManager>().PlayEffects("PowerUp"); //playe the sound
        Destroy(GameObject.FindWithTag("Speed"));//delete the powerup prefab
        speed -= 10; //make the player slower
        transform.GetChild(3).gameObject.SetActive(true);    //add a particle around the player
        yield return new WaitForSeconds(Shop.SpeedShow);   //after the show time is done
        speed += 10; //make the player faster
        Cube1.GetComponent<BoxCollider>().enabled = true;
        Cube2.GetComponent<BoxCollider>().enabled = true;
        Cube3.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(3).gameObject.SetActive(false);//remove the particle around the player

    }

}
