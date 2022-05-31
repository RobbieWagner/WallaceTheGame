using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunTutorial : MonoBehaviour
{

    public Character character;
    public Transform characterT;

    public string openingDialoguePath;
    public string tutorialPart2Path;
    public string tutorialPart3Path;
    public string tutorialPart4Path;
    public string tutorialPart5Path;
    public string tutorialPart6Path;
    public string tutorialPart7Path;
    public string tutorialPart8Path;

    public GameObject wasdControls;

    bool hasMoved = false;

    public Gate tutorialGate;

    public GameObject magicGate;

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

        while(
            !(
                (characterT.position.x > -2 
                && characterT.position.x < 2
                && characterT.position.y > 20.4)
                ||(characterT.position.x > -27 
                && characterT.position.x < -1 
                && characterT.position.y > 20.25)
                ||(characterT.position.y > 1 
                && characterT.position.y < 4 
                && characterT.position.x > 20))) yield return new WaitForSeconds(.3f);
        
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart4Path)));

        while(!
                (characterT.position.x > -1
                && characterT.position.x < 14 
                && characterT.position.y >= 50)
                && !(character.score == 30)) yield return new WaitForSeconds(.3f);

        if(!(character.score == 30))
        {
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart5Path)));
            while(character.score != 30) yield return new WaitForSeconds(.3f);
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart6Path)));
        } 
        else
        {
            while(character.score != 30) yield return new WaitForSeconds(.3f);
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart7Path)));
        }

        magicGate.SetActive(false);

        while(!
                (characterT.position.x > -1
                && characterT.position.x < 14 
                && characterT.position.y >= 55)) yield return new WaitForSeconds(.3f);
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart8Path)));

        StopCoroutine(Tutorial());
    }
}
