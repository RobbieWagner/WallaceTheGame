using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialoguePath;
    public string alternatePath;
    public Color color;
    public AudioSource dialogueSound;
    public float lowPitch;
    public float highPitch;
    public Character character;

    public bool interactedOnce;

    void Start()
    {
        interactedOnce = false;
    }

    public IEnumerator FirstInteraction()
    {
        //sets interacted once to true. 
        //Needs to be delayed in order for other coroutines to end.
        yield return new WaitForSeconds(.1f);
        interactedOnce = true;
        StopCoroutine(FirstInteraction());
    }

    public IEnumerator PassInfoIntoReadDialogue(string path)
    {
        bool resetInteractedOnce = false;
        if(!interactedOnce) resetInteractedOnce = true;
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(path), dialogueSound, color, lowPitch, highPitch, true, this));
        if(resetInteractedOnce) interactedOnce = false;
        StopCoroutine(PassInfoIntoReadDialogue(path));
    }
}
