using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class PushableBridge : MonoBehaviour
{
    public PushableObjectBoundary northData;
    public PushableObjectBoundary eastData;
    public PushableObjectBoundary southData;
    public PushableObjectBoundary westData;

    public Rigidbody2D rb2d;

    public bool pushable;
    public Character character;

    public GameObject goal;
    public bool goalReached;
    public BoxCollider2D[] bridgeRails; 
    public BoxCollider2D[] killingColliders;
    public TilemapCollider2D[] chasms;
    public Rigidbody2D bridgeRB;

    void Start()
    {
        foreach(BoxCollider2D collider in bridgeRails)
        {
            collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        foreach(BoxCollider2D collider in killingColliders)
        {
            collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        goalReached = false;
    }

    void Update()
    {
        if(goalReached)
        {
            //prevent bridge from being moved again!!!
            gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            foreach(BoxCollider2D collider in bridgeRails)
            {
                collider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }


        if(character.canPushThings && bridgeRB != null)
        {
            bridgeRB.bodyType = RigidbodyType2D.Dynamic;
        }
        else if (bridgeRB != null)
        {
            bridgeRB.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == character.gameObject)
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
            rb2d.velocity = Vector2.zero;
            goalReached = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        bool chasmCovered = false;
        foreach(TilemapCollider2D chasm in chasms)
        {
            if(chasm.gameObject == collision.gameObject) 
            {
                chasmCovered = true;
            }
        }
        if(goalReached && chasmCovered)  
        {  
            collision.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            foreach(BoxCollider2D collider in killingColliders)
            {
                collider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }

    public void ResetBridge()
    {
        foreach(BoxCollider2D collider in bridgeRails)
        {
            collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        foreach(BoxCollider2D collider in killingColliders)
        {
            collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        //create a new rigidbody, set gravity scale to 0, put it on dynamic, make sure this rigid body is associated with other objects in scripts
        if(rb2d == null)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        goalReached = false;
    }
}
