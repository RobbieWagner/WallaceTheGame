using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public IEnumerator MoveCamera(Vector2 stoppingPlace, float movingIncrement)
    {
        while(Vector2.Distance(gameObject.transform.position, stoppingPlace) >= movingIncrement)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, stoppingPlace, movingIncrement);
            yield return new WaitForSeconds(.01f);
        }
        StopCoroutine(MoveCamera(stoppingPlace, movingIncrement));
    }
}
