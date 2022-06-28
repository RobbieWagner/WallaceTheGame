using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedGirder : MonoBehaviour
{

    public GirderButton button;
    public Collider2D[] collidersToIgnore;

    private bool foundCollider;

    void Start()
    {
        foundCollider = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(Collider2D collider in collidersToIgnore)
        {
            if(collision.collider == collider) foundCollider = true;
        }
        if(!foundCollider) button.resetMechanism();
        else foundCollider = false;
    }
}
