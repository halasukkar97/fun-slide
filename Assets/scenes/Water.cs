using UnityEngine;

public class Water : MonoBehaviour {
    
    public GameObject playerRef;

    public  void FixedUpdate()
    {
        //this one is to follow the player around
      this.transform.position = new Vector3(playerRef.transform.position.x, 0, playerRef.transform.position.z);

    }

}
