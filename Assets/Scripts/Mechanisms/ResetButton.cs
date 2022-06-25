using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Character character;

    public PushableBridge bridge;

    public GameObject[] objectsToBeReset;
    private Vector2[] objectPositions;

    // Start is called before the first frame update
    void Start()
    {
        objectPositions = new Vector2[objectsToBeReset.Length];
        for(int i = 0; i < objectPositions.Length; i++)
        {
            objectPositions[i] = objectsToBeReset[i].transform.position;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Character>() != null && Input.GetKey(KeyCode.J) && character.canPushButtons)
        {
            for(int i = 0; i < objectPositions.Length; i++)
            {
                objectsToBeReset[i].transform.position = objectPositions[i];
                PushableBridge bridge = objectsToBeReset[i].GetComponent<PushableBridge>();
                if(bridge != null && bridge.goalReached && bridge.chasmCovered)
                {
                    bridge.ResetBridge();
                }
            }
        }
    }
}
