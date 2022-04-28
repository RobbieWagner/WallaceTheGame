using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunTutorial : MonoBehaviour
{

    public Character character;
    public string openingDialoguePath;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tutorial()
    {
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(openingDialoguePath)));
        StopCoroutine(Tutorial());
    }
}
