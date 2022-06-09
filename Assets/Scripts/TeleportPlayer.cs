using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    
    public TeleportPlayer otherTeleporter;
    public Vector2 teleportLocation;

    public Character character;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject == character.gameObject)
        {
            character.transform.position = otherTeleporter.teleportLocation;
        }
    }
}
