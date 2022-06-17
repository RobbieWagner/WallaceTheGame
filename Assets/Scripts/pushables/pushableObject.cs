using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushableObject : MonoBehaviour
{

    public PushableObjectBoundary northData;
    public PushableObjectBoundary eastData;
    public PushableObjectBoundary southData;
    public PushableObjectBoundary westData;

    public Rigidbody2D rb2d;

    public Character character;

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

    void Update()
    {
        if(character.canPushThings && rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else if (rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }
}
