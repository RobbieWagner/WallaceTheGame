using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunHatSection : MonoBehaviour
{

    public Character character;
    public BoxCollider2D characterBC;
    public Transform characterT;

    public string hatsPart1Path;
    public string hatsPart2Path;
    public string hatsPart3Path;

    public GameObject hatsParent;

    public CameraController cameraController;

    // skip the first section (used for testing)
    public bool skipTutorial;

    public Friend wallacesFriend;
    public DialogueHolder wallacesFriendsDH;
    public GameObject idleWallace;

    public LayerMask tutorial;
    public float boxCastDistance;

    bool tutorialBelow;
    bool tutorialAbove;
    bool tutorialLeft;
    bool tutorialRight;
    bool hasGivenHatIntroduction;

    // Start is called before the first frame update
    void Start()
    {
        if(skipTutorial) StartCoroutine(HatsSection());

        tutorialAbove = false;
        tutorialBelow = false;
        tutorialLeft = false;
        tutorialRight = false;
        hasGivenHatIntroduction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasGivenHatIntroduction)
        {
            RaycastHit2D hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.down, boxCastDistance, tutorial);

            if (!hit)
            {
                hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.up, boxCastDistance, tutorial);
            }
            if (!hit)
            {
                hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.right, boxCastDistance, tutorial);
            }
            if (!hit)
            {
                hit = Physics2D.BoxCast(characterBC.bounds.center, characterBC.bounds.size, 0f, Vector2.left, boxCastDistance, tutorial);
            }
            if (hit && character.canMove)
            {
                hasGivenHatIntroduction = true;
                StartCoroutine(IntroduceHats());
            }
        }
    }

    public IEnumerator HatsSection()
    {
        hatsParent.SetActive(true);
        idleWallace.SetActive(true);

        yield return new WaitForSeconds(1f);

        StopCoroutine(HatsSection());
    }

    public IEnumerator IntroduceHats()
    {
        Vector3 idleWallacePos = idleWallace.gameObject.transform.position;
        yield return StartCoroutine(cameraController.MoveCamera(new Vector3(idleWallacePos.x, idleWallacePos.y, -10), 10 * Time.deltaTime));
        yield return StartCoroutine(wallacesFriendsDH.PassInfoIntoReadDialogue(hatsPart1Path));
        character.StopCharacter();
        yield return StartCoroutine(cameraController.ResetCamera());
        character.canMove = true;

        //Wallace puts on hat and gains the power to pick pumpkins!

        StopCoroutine(IntroduceHats());
    }
}
