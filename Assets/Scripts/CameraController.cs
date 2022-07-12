using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Character character;
    bool moving;
    bool doneMoving;
    float step;
    Vector3 destination;

    void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, -10);
        moving = false;
        doneMoving = false;
    }

    void Update()
    {
        if(moving)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destination, step);
            if(Vector3.Distance(destination, gameObject.transform.position) < step) doneMoving = true;
        }
    }

    public IEnumerator ResetCamera()
    {
        yield return StartCoroutine(MoveCamera(new Vector3(character.gameObject.transform.position.x, character.gameObject.transform.position.y, -10), 6 * Time.deltaTime));
        StopCoroutine(ResetCamera());
    }

    public IEnumerator MoveCamera(Vector3 stoppingPlace, float movingIncrement)
    {
        destination = stoppingPlace;
        step = movingIncrement;
        moving = true;

        while(!doneMoving)
        {
            yield return null;
        }

        moving = false;
        doneMoving = false;

        StopCoroutine(MoveCamera(stoppingPlace, movingIncrement));
    }
}
