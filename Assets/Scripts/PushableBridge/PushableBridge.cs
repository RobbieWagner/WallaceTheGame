using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBridge : MonoBehaviour
{
    public BridgeBoxData northData;
    public BridgeBoxData eastData;
    public BridgeBoxData southData;
    public BridgeBoxData westData;

    public bool pushable;
    public bool goalReached;
    public Character character;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == character.gameObject)
        {
            Debug.Log("hi");
            Transform bridgeT = gameObject.transform;
            if(northData.wallaceTouching) 
            {
                bridgeT.position = new Vector3(
                bridgeT.position.x, 
                bridgeT.position.y - 5,
                bridgeT.position.z );
            }
            if(eastData.wallaceTouching) 
            {
                bridgeT.position = new Vector3(
                bridgeT.position.x - 5, 
                bridgeT.position.y,
                bridgeT.position.z );
            }
            if(southData.wallaceTouching) 
            {
                bridgeT.position = new Vector3(
                bridgeT.position.x, 
                bridgeT.position.y + 5,
                bridgeT.position.z );
            }
            if(westData.wallaceTouching) 
            {
                bridgeT.position = new Vector3(
                bridgeT.position.x + 5, 
                bridgeT.position.y,
                bridgeT.position.z );
            }
        }
    }
}
