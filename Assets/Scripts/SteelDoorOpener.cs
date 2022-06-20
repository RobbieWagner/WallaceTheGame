using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelDoorOpener : MonoBehaviour
{
    public Animator SteelDoor;
    public GameObject SteelDoorsCollider;
    public Character character;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && character.canPushButtons)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        SteelDoor.SetBool("Opening", true);
        yield return new WaitForSeconds(1.7f);
        SteelDoorsCollider.SetActive(false);
        StopCoroutine(OpenDoor());
    }
}
