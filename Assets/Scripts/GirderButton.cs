using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirderButton : MonoBehaviour
{

    public Rigidbody2D girderRB2D;
    public Character character;
    
    public Transform girderT;
    private Vector2 girderTPos;
    public Vector2 finalPosition;

    private bool buttonOn;

    void Start()
    {
        girderTPos = girderT.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == character.gameObject && character.canOpenDoors)
        {
            buttonOn = true;
        }
    }

    void Update()
    {
        if(buttonOn && finalPosition != girderTPos)
        {
            girderRB2D.bodyType = RigidbodyType2D.Dynamic;
            girderRB2D.MovePosition(finalPosition);
        }
        else
        {
            girderRB2D.velocity = Vector2.zero;
            girderRB2D.bodyType = RigidbodyType2D.Static;
        }
    }

}
