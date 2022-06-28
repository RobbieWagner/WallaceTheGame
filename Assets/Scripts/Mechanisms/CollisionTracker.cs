using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    public bool colliding;

    void Start()
    {
        colliding = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        colliding = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        colliding = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }
}
