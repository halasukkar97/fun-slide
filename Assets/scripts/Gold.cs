using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    //bool isSpawned = false;
    private Scores score;
    public GameObject ps; //particlesystem

    void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
      
    }

    void OnTriggerEnter(Collider col)
    {
        //your player should have the "player" tag
        if (col.tag.Contains("Player"))
        {
            Scores.GoldCount += 1;
            
            Instantiate(ps, transform.position, Quaternion.identity);
            //GetComponent<AudioSource>().Play();
            this.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject);
           // Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
        }
        //else if (col.tag.Equals("Spawner") && !isSpawned)
        //{
        //    this.GetComponent<MeshRenderer>().enabled = true;
        //    this.GetComponent<Animator>().enabled = true;
        //}

    }

}
