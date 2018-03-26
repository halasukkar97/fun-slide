using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    bool isSpawned = false;
    private Scores score;

    //particle Systems
    public GameObject ps1;             
    public GameObject ps2;
    public GameObject ps3;
    public GameObject ps4;

    //change values
    public bool less500 = true;
    public bool over500 = false;
    public bool over1000 = false;
    public bool over2500 = false;




    void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
      
    }

    private void Update()
    {
        if(less500)
        {
           
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if(Scores.ScoreCount >= 500)
        {
            less500 = false;
            over500 = true;
            
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;

        }

        if (Scores.ScoreCount >= 1000)
        {
            less500 = false;
            over500 = false;
            over1000 = true;
           
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (Scores.ScoreCount >= 2500)
        {
            less500 = false;
            over500 = false;
            over1000 = false;
            over2500 = true;
            
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //your player should have the "player" tag
        if (col.tag.Contains("Player"))
        {
           if(less500)
            {
                Scores.GoldCount += 1;
                Instantiate(ps1, transform.position, Quaternion.identity);
                //GetComponent<AudioSource>().Play();
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject);
                // Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
            }
            else if(over500)
            {
                Scores.GoldCount += 2;
                Instantiate(ps2, transform.position, Quaternion.identity);
                //GetComponent<AudioSource>().Play();
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject);
                // Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
            }
            else if (over1000)
            {
                Scores.GoldCount += 3;
                Instantiate(ps3, transform.position, Quaternion.identity);
                //GetComponent<AudioSource>().Play();
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject);
                // Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
            }
            else if (over2500)
            {
                Scores.GoldCount += 4;
                Instantiate(ps4, transform.position, Quaternion.identity);
                //GetComponent<AudioSource>().Play();
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject);
                // Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
            }
           
        }
        else if (col.tag.Equals("Spawner") && !isSpawned)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            //this.GetComponent<Animator>().enabled = true;
        }

    }

}
