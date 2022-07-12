using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

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

    public void ResetCamera()
    {
        //may need to change if global and not local
        StartCoroutine(MoveCamera(new Vector3(0, 0, -10), 6 * Time.deltaTime));
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
