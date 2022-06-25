using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public Animator buttonAnimator;

    public Rigidbody2D objectToMove;
    public Character character;

    public Transform objectT;
    public Collider2D objectC;
    public Vector2 initialPosition;
    public Vector2 finalPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = objectT.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        buttonAnimator.SetBool("ButtonPressed", true);
        objectToMove.bodyType = RigidbodyType2D.Dynamic;
        objectC.enabled = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(objectT.position.x != finalPosition.x && objectT.position.y != finalPosition.y)
        {
            objectT.position = Vector2.MoveTowards(objectT.position, finalPosition, .01f);
        }
        else
        {
            objectToMove.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        buttonAnimator.SetBool("ButtonPressed", false);
        objectToMove.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(resetMechanism());
    }

    IEnumerator resetMechanism()
    {
        while(objectT.position.x != initialPosition.x && objectT.position.y != initialPosition.y)
        {
            objectT.position = Vector2.MoveTowards(objectT.position, initialPosition, .01f);
            yield return new WaitForSeconds(.001f);
        }
        objectC.enabled = true;
        objectToMove.bodyType = RigidbodyType2D.Static;
        StopCoroutine(resetMechanism());
    }
}
