using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBoxData : MonoBehaviour
{
    //side of the bridge the collider is on. Either N for North, E for East, S for South, and W for West (use caps)
    public char direction;
    public bool wallaceTouching;
    public Character character;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hello");
        if(collision.gameObject == character.gameObject) wallaceTouching = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject == character.gameObject) wallaceTouching = false;
    }
}
