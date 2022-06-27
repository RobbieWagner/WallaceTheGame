using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PressurePlate : MonoBehaviour
{

    //New Skill: To change the color of a tilemap, import tilemaps and get the tilemap component.

    public Animator buttonAnimator;

    public Rigidbody2D objectToMove;
    public Character character;

    public Transform objectT;
    public Collider2D objectC;
    public Tilemap objectTilemap;
    public Vector2 initialPosition;
    public Vector2 finalPosition;

    private bool objectRising;

    private ArrayList buttonPressers;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = objectT.position;
        objectRising = false;
        buttonPressers = new ArrayList();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        objectRising = true;
        buttonAnimator.SetBool("ButtonPressed", true);
        objectToMove.bodyType = RigidbodyType2D.Dynamic;
        objectC.enabled = false;
        buttonPressers.Add(null);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(objectC.enabled == true) objectC.enabled = false;
        if(objectT.position.x != finalPosition.x || objectT.position.y != finalPosition.y)
        {
            objectT.position = Vector2.MoveTowards(objectT.position, finalPosition, .1f);
        }
        else
        {
            objectToMove.bodyType = RigidbodyType2D.Static;
        }

        if(!(objectTilemap.color.a <= .1f))
        {
            objectTilemap.color = new Vector4(objectTilemap.color.r, objectTilemap.color.g, objectTilemap.color.b, objectTilemap.color.a - .01f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        buttonPressers.Remove(null);
        if(!buttonPressers.Contains(null))
        {
            objectRising = false;
            buttonAnimator.SetBool("ButtonPressed", false);
            objectToMove.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(resetMechanism());
        }
    }

    IEnumerator resetMechanism()
    {
        while(!(objectT.position.x <= initialPosition.x) || !(objectT.position.y <= initialPosition.y) && !objectRising)
        {
            objectT.position = Vector2.MoveTowards(objectT.position, initialPosition, .1f);
            yield return new WaitForSeconds(.009f);
            if(!(objectTilemap.color.a >= 1f))
            {
                objectTilemap.color = new Vector4(objectTilemap.color.r, objectTilemap.color.g, objectTilemap.color.b, objectTilemap.color.a + .01f);
            }
        }
        if(objectTilemap.color.a < 1f) objectTilemap.color = new Vector4(objectTilemap.color.r, objectTilemap.color.g, objectTilemap.color.b, 1);
        objectC.enabled = true;
        objectToMove.bodyType = RigidbodyType2D.Static;
        StopCoroutine(resetMechanism());
    }

    // void Update()
    // {
    //     if(objectC.enabled && (objectT.position.x != initialPosition.x || objectT.position.y != initialPosition.y) && objectRising)
    //     {
    //         objectC.enabled = false;
    //     }
    //     else if(objectT.position.x == initialPosition.x || objectT.position.y == initialPosition.y)
    //     {
    //         objectC.enabled = true;
    //     }
    // }
}
