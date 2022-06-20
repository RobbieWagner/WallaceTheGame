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
        if(character.canPushThings && rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else if (rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rb2d.bodyType = RigidbodyType2D.Static;
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
