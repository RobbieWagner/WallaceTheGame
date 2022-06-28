using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirderButton : MonoBehaviour
{

    public Rigidbody2D girderRB2D;
    public Character character;
    
    public Transform girderT;
    public Vector2 finalPosition;
    public Vector2 initialPosition;

    private bool resetting;

    private bool buttonOn;

    void Start()
    {
        initialPosition = girderT.position;
        resetting = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == character.gameObject && character.canPushButtons)
        {
            buttonOn = true;
        }
    }

    void Update()
    {
        if(buttonOn && (finalPosition.x != girderT.position.x || finalPosition.y != girderT.position.y) && !resetting)
        {
            girderRB2D.bodyType = RigidbodyType2D.Dynamic;
            girderT.position = Vector2.MoveTowards(girderT.position, finalPosition, .01f);
        }
        else if(buttonOn && (initialPosition.x != girderT.position.x || initialPosition.y != girderT.position.y) && resetting)
        {
            girderRB2D.bodyType = RigidbodyType2D.Dynamic;
            girderT.position = Vector2.MoveTowards(girderT.position, initialPosition, .1f);
        }
        else if(resetting)
        {
            buttonOn = false;
            girderRB2D.velocity = Vector2.zero;
            girderRB2D.bodyType = RigidbodyType2D.Static;
            resetting = false;
        }
        else
        {
            girderRB2D.velocity = Vector2.zero;
            girderRB2D.bodyType = RigidbodyType2D.Static;
        }
    }

    public void resetMechanism()
    {
        resetting = true;
    }
}
