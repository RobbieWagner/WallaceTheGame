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

        while(
            !(
                (characterT.position.x > 30 
                && characterT.position.x < 33 
                && characterT.position.y < 20)
                ||(characterT.position.x > -27 
                && characterT.position.x < -1 
                && characterT.position.y > 20.25)
                ||(characterT.position.y > 1 
                && characterT.position.y < 4 
                && characterT.position.x > 20))) yield return new WaitForSeconds(.3f);
        
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart4Path)));

        StopCoroutine(Tutorial());
    }
}
