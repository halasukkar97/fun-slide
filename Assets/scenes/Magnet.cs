using UnityEngine;

public class Magnet : MonoBehaviour {


    void Start()
    {
        gameObject.SetActive(false);  //start the game by turning this off
    }

    //bring the coins to the player
    public void FixedUpdate()
    {
        RaycastHit[] hits;
        Ray r = new Ray(transform.position, transform.forward);
        hits = Physics.SphereCastAll(r, 15f);
        
        foreach (var x in hits)   
        {
            if (x.collider.CompareTag("Coin"))
                x.collider.transform.position = Vector3.MoveTowards(x.transform.position, transform.position, 12f * Time.deltaTime);
        }
    }
}
