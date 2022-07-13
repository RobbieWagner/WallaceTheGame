using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunTutorial : MonoBehaviour
{

    public Character character;
    public Transform characterT;
    public BoxCollider2D characterBC;
    public float boxCastDistance;
    public LayerMask hazard;

    public string tutorialPart1Path;
    public string tutorialPart2Path;
    public string tutorialPart3Path;
    public string tutorialPart4Path;
    public string tutorialPart5Path;

    public GameObject wasdControls;

    public GameObject pumpkinTutorial1;
    public GameObject pumpkinTutorial2;

    bool hasMoved = false;

    public Gate tutorialGate;

    public GameObject magicGate;

    public Friend wallacesFriend;
    public CameraController cameraController;

    public RunHatSection runHatSection;

    bool pickedUpPumpkin;
    bool flashedPumpkinTutorial2;

    bool hasGivenAllergyTutorial;

    bool hazardAbove;
    bool hazardBelow;
    bool hazardRight;
    bool hazardLeft;

    public DialogueHolder wallacesFriendsDH;

    // Start is called before the first frame update
    void Start()
    {
        hasMoved = false;
        wasdControls.SetActive(false);
        pickedUpPumpkin = false;

        flashedPumpkinTutorial2 = false;
        hasGivenAllergyTutorial = false;

        hazardAbove = false;
        hazardBelow = false;
        hazardRight = false;
        hazardLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(character.canMove &&(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))) hasMoved = true;

        if(character.score > 0 && !flashedPumpkinTutorial2) StartCoroutine(FlashPumpkinTutorial2());

        if(!hasGivenAllergyTutorial)
        {
            RaycastHit2D hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.down, boxCastDistance, hazard);
            if(hit) hazardBelow = true;

            if (!hit)
            {
                hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.up, boxCastDistance, hazard);
                if(hit) hazardAbove = true;
            }
            if (!hit)
            {
                hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.right, boxCastDistance, hazard);
                if(hit) hazardRight = true;
            }
            if (!hit)
            {
                hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.left, boxCastDistance, hazard);
                if(hit) hazardLeft = true;
            }
            if (hit && character.canMove)
            {
                hasGivenAllergyTutorial = true;
                StartCoroutine(WarnPlayerOfAllergies());
            }
        }
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
        yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart1Path));
        character.StopCharacter();

        wallacesFriend.gameObject.transform.position = new Vector2(-1f, 21.23f);
        wallacesFriend.gameObject.SetActive(true);
        yield return StartCoroutine(cameraController.MoveCamera(new Vector3(0, 20, -10), 7 * Time.deltaTime));

        yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart2Path));
        character.StopCharacter();

        yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(wallacesFriend.gameObject.transform.position.x, 30), "n", 7 * Time.deltaTime));
        wallacesFriend.gameObject.SetActive(false);
        yield return StartCoroutine(cameraController.ResetCamera());
        character.canMove = true;

        pumpkinTutorial1.SetActive(true);
        yield return new WaitForSeconds(3f);
        pumpkinTutorial1.SetActive(false);

        while(character.score < 30) yield return null;

        yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart5Path));

        StopCoroutine(Tutorial());
    }

    IEnumerator FlashPumpkinTutorial2()
    {
        pumpkinTutorial2.SetActive(true);
        yield return new WaitForSeconds(3f);
        pumpkinTutorial2.SetActive(false);
        flashedPumpkinTutorial2 = true;

        StopCoroutine(FlashPumpkinTutorial2());
    }

    IEnumerator WarnPlayerOfAllergies()
    {

        yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart3Path));
        character.StopCharacter();

        //runs tutorial based off the direction the detected hazard is in
        if(hazardLeft)
        {
            wallacesFriend.gameObject.transform.position = new Vector2(character.gameObject.transform.position.x + 9, character.gameObject.transform.position.y);
            wallacesFriend.gameObject.SetActive(true);
            yield return StartCoroutine(cameraController.MoveCamera(new Vector3(character.gameObject.transform.position.x + 3.5f, character.gameObject.transform.position.y, -10), 8 * Time.deltaTime));
            yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart4Path));
            character.StopCharacter();
            yield return StartCoroutine(cameraController.ResetCamera());
            yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(wallacesFriend.gameObject.transform.position.x + 5, wallacesFriend.gameObject.transform.position.y), "e", 10 * Time.deltaTime));
        }
        else if(hazardRight)
        {
            wallacesFriend.gameObject.transform.position = new Vector2(character.gameObject.transform.position.x - 9, character.gameObject.transform.position.y);
            wallacesFriend.gameObject.SetActive(true);
            yield return StartCoroutine(cameraController.MoveCamera(new Vector3(character.gameObject.transform.position.x - 3.5f, character.gameObject.transform.position.y, -10), 8 * Time.deltaTime));
            yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart4Path));
            character.StopCharacter();
            yield return StartCoroutine(cameraController.ResetCamera());
            yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(wallacesFriend.gameObject.transform.position.x - 5, wallacesFriend.gameObject.transform.position.y), "w", 10 * Time.deltaTime));
        }
        else if(hazardBelow)
        {
            wallacesFriend.gameObject.transform.position = new Vector2(character.gameObject.transform.position.x, character.gameObject.transform.position.y + 9);
            wallacesFriend.gameObject.SetActive(true);
            yield return StartCoroutine(cameraController.MoveCamera(new Vector3(character.gameObject.transform.position.x, character.gameObject.transform.position.y + 3.5f, -10), 8 * Time.deltaTime));
            yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart4Path));
            character.StopCharacter();
            yield return StartCoroutine(cameraController.ResetCamera());
            yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(wallacesFriend.gameObject.transform.position.x, wallacesFriend.gameObject.transform.position.y + 5), "n", 10 * Time.deltaTime));
        }
        else
        {
            wallacesFriend.gameObject.transform.position = new Vector2(character.gameObject.transform.position.x, character.gameObject.transform.position.y - 9);
            wallacesFriend.gameObject.SetActive(true);
            yield return StartCoroutine(cameraController.MoveCamera(new Vector3(character.gameObject.transform.position.x, character.gameObject.transform.position.y - 3.5f, -10), 8 * Time.deltaTime));
            yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(tutorialPart4Path));
            character.StopCharacter();
            yield return StartCoroutine(cameraController.ResetCamera());
            yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(wallacesFriend.gameObject.transform.position.x, wallacesFriend.gameObject.transform.position.y - 5), "s", 10 * Time.deltaTime));
        }

        wallacesFriend.gameObject.SetActive(false);

        character.canMove = true;

        StopCoroutine(WarnPlayerOfAllergies());
    }
}
