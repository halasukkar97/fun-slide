using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// the powerups we have
/// </summary>
public enum PowerUpType
{ 
    Faster,
    Shield,
    Magnet,
}

public class PowerUps : MonoBehaviour {

    
    private PlayerMovment playerScript;
    private Shop shop;
    public PowerUpType PowerType;
    private static Action[] _powerUpActions;

    // Use this for initialization
    void Start () {
        if (_powerUpActions == null) Init();
        if (playerScript == null) playerScript = GameObject.FindObjectOfType<PlayerMovment>();
        if (shop == null) shop = GameObject.FindObjectOfType<Shop>();
    }

    //to control which powerup we are going to use
    void Init()
    {
        _powerUpActions = new Action[3];
        _powerUpActions[0] = () => StartCoroutine(Faster());
        _powerUpActions[1] = () => StartCoroutine(Shield());
        _powerUpActions[2] = () => StartCoroutine(Magnet());
        for (int i = 0; i < _powerUpActions.Length; i++)
            _powerUpActions[i] += () => GetComponent<Renderer>().enabled = false;
    }
    
    //when the player enter the object coliider
    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        _powerUpActions[(int)PowerType]();
    }

    //when the player slide fatser
    IEnumerator Faster()
    {
        PlayerMovment player = Component.FindObjectOfType<PlayerMovment>();
        PlayerMovment.speed += 20;
        player._isInvincible = true;
        GameObject speed = Component.FindObjectOfType<PlayerMovment>().gameObject;
        speed = speed.transform.GetChild(3).gameObject;
        speed.SetActive(true);
        yield return new WaitForSeconds(Shop.SpeedShow);
        PlayerMovment.speed -= 20;
        player._isInvincible = false;
        speed.SetActive(false);
    }

    //when the player get the maget power ups
    IEnumerator Magnet()
    {
        GameObject go = Component.FindObjectOfType<PlayerMovment>().gameObject;
        GameObject magnet = Component.FindObjectOfType<PlayerMovment>().gameObject;
        go = go.transform.GetChild(0).gameObject;
        magnet = magnet.transform.GetChild(1).gameObject;
        go.SetActive(true);
        magnet.SetActive(true);
        yield return new WaitForSeconds(Shop.MagnetShow);
        go.SetActive(false);
        magnet.SetActive(false);

    }

    //when te player get the shield power up
    IEnumerator Shield()
    {
        GameObject shield = Component.FindObjectOfType<PlayerMovment>().gameObject;
        PlayerMovment player = Component.FindObjectOfType<PlayerMovment>();
        shield = shield.transform.GetChild(2).gameObject;
        player._isInvincible = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(Shop.SpeedShow);
        player._isInvincible = false;
        shield.SetActive(false);
        
    }


}
