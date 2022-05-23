using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunTutorial : MonoBehaviour
{

    public Character character;
    public string openingDialoguePath;
    public string tutorialPart2Path;
    public string tutorialPart3Path;

    public GameObject wasdControls;

    bool hasMoved = false;

    public Gate tutorialGate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial());

        hasMoved = false;
        wasdControls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(character.canMove &&(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))) hasMoved = true;
    }

    IEnumerator Tutorial()
    {
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(openingDialoguePath)));

        wasdControls.SetActive(true);
        while(!hasMoved) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(.5f);
        wasdControls.SetActive(false);

        yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart2Path)));

        while(!tutorialGate.opened) yield return new WaitForSeconds(.3f);

        yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart3Path)));

        StopCoroutine(Tutorial());
    }
}
