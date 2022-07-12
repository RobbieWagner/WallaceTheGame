using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunTutorial : MonoBehaviour
{

    public Character character;
    public Transform characterT;

    public string tutorialPart1Path;
    public string tutorialPart2Path;
    public string tutorialPart3Path;
    public string tutorialPart4Path;
    public string tutorialPart5Path;

    public GameObject wasdControls;

    bool hasMoved = false;

    public Gate tutorialGate;

    public GameObject magicGate;

    public Friend wallacesFriend;
    public CameraController cameraController;

    public RunHatSection runHatSection;

    // Start is called before the first frame update
    void Start()
    {
        hasMoved = false;
        wasdControls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(character.canMove &&(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))) hasMoved = true;
    }

    public IEnumerator Tutorial()
    {
        //pop up wasd controls for players that need it
        wasdControls.SetActive(true);
        
        while(!hasMoved)
        {
            yield return new WaitForSeconds(.25f);
        }

        wasdControls.SetActive(false);

        //wait for the gate to open before running the next bit of dialogue
        while(!tutorialGate.opened) yield return new WaitForSeconds(.3f);

        character.canMove = false;
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart1Path)));
        character.StopCharacter();

        wallacesFriend.gameObject.transform.position = new Vector2(-1f, 21.23f);
        wallacesFriend.gameObject.SetActive(true);
        yield return StartCoroutine(cameraController.MoveCamera(new Vector3(0, 20, -10), 7 * Time.deltaTime));

        yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart2Path)));
        character.StopCharacter();

        yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(wallacesFriend.gameObject.transform.position.x, 30), "n", 7 * Time.deltaTime));
        wallacesFriend.gameObject.SetActive(false);
        yield return StartCoroutine(cameraController.ResetCamera());
        character.canMove = true;

        //run if the player runs into anything dangerous
        while(!
                (characterT.position.x > -1
                && characterT.position.x < 14 
                && characterT.position.y >= 50)
                && !(character.score == 30)) yield return new WaitForSeconds(.3f);

        if(!(character.score == 30))
        {
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart2Path)));
            while(character.score != 30) yield return new WaitForSeconds(.3f);
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart3Path)));
        } 
        else
        {
            while(character.score != 30) yield return new WaitForSeconds(.3f);
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart4Path)));
        }

        magicGate.SetActive(false);

        while(!
                (characterT.position.x > -1
                && characterT.position.x < 14 
                && characterT.position.y >= 55)) yield return new WaitForSeconds(.3f);
            yield return StartCoroutine(character.ReadDialogue(new StreamReader(tutorialPart5Path)));

        runHatSection.gameObject.SetActive(true);
        StartCoroutine(runHatSection.HatsSection());

        StopCoroutine(Tutorial());
    }
}
