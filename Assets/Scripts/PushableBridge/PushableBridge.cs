using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBridge : MonoBehaviour
{
    public BridgeBoxData northData;
    public BridgeBoxData eastData;
    public BridgeBoxData southData;
    public BridgeBoxData westData;

    public Rigidbody2D rb2d;

    public bool pushable;
    public bool goalReached;
    public Character character;

    public GameObject goal;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == character.gameObject && character.canPushThings)
        {
            if(northData.wallaceTouching) 
            {
                rb2d.velocity = new Vector2(0, -3);
            }
            if(eastData.wallaceTouching) 
            {
                rb2d.velocity = new Vector2(-3, 0);
            }
            if(southData.wallaceTouching) 
            {
                rb2d.velocity = new Vector2(0, 3);
            }
            if(westData.wallaceTouching) 
            {
                rb2d.velocity = new Vector2(3, 0);
            }
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == goal.gameObject)
        {
            Debug.Log("goalReached");
            rb2d.velocity = Vector2.zero;
            goalReached = true;
        }
    }
}
