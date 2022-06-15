using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObjectBoundary : MonoBehaviour
{
    //side of the bridge the collider is on. Either N for North, E for East, S for South, and W for West (use caps)
    public char direction;
    public bool wallaceTouching;
    public Character character;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == character.gameObject) wallaceTouching = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == character.gameObject) wallaceTouching = false;
    }
}
