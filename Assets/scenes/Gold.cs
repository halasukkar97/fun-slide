using UnityEngine;

public class Gold : MonoBehaviour {

    //materials to change gold colors
    public Material[] material;
    Renderer rend;

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
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
      
    }

    private void Update()
    {
        transform.Rotate(0, 5, 0, Space.Self);  //to make the gold rotate around it self

        if(less500)
        {
            //change the gold color
            rend.sharedMaterial = material[0];
        }
        if(Scores.ScoreCount >= 500)
        {
            less500 = false;
            over500 = true;

            //change the gold color
            rend.sharedMaterial = material[1];

        }

        if (Scores.ScoreCount >= 1000)
        {
            less500 = false;
            over500 = false;
            over1000 = true;

            //change the gold color
            rend.sharedMaterial = material[2];
        }

        if (Scores.ScoreCount >= 2500)
        {
            less500 = false;
            over500 = false;
            over1000 = false;
            over2500 = true;

            //change the gold color
            rend.sharedMaterial = material[3];
        }
    }

   
            void OnTriggerEnter(Collider col)
    {
        //your player should have the "player" tag or the "magnet Collider" to collect money
        if (col.tag.Contains("Player")|| col.tag.Contains("MagnetCol"))
        {

            //change gold value with the time, change color, playsound,destroy at the end.
           if(less500)
            {
                Scores.GoldCount += 1;
                 var _ps1= Instantiate(ps1, transform.position, Quaternion.identity);
                _ps1.transform.SetParent(transform);
                FindObjectOfType<AudioManager>().PlayEffects("Gold");
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject, 2f);
            }
            else if(over500)
            {
                Scores.GoldCount += 4;
                var _ps2 = Instantiate(ps2, transform.position, Quaternion.identity);
                _ps2.transform.SetParent(transform);
                FindObjectOfType<AudioManager>().PlayEffects("Gold");
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject, 2f);
            }
            else if (over1000)
            {
                Scores.GoldCount += 8;
                var  _ps3 = Instantiate(ps3, transform.position, Quaternion.identity);
                _ps3.transform.SetParent(transform);
                FindObjectOfType<AudioManager>().PlayEffects("Gold");
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject, 2f);
            }
            else if (over2500)
            {
                Scores.GoldCount += 15;
                var _ps4 = Instantiate(ps4, transform.position, Quaternion.identity);
                _ps4.transform.SetParent(transform);
                FindObjectOfType<AudioManager>().PlayEffects("Gold");
                this.GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject, 2f);
               
            }
           
        }
       

    }

}
