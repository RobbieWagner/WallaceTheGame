using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunGameOpening : MonoBehaviour
{
    //Runs the opening game dialogue/cutscene until right after Wallace's friend wakes him up
    public Character character;
    public Friend wallacesFriend;
    public GameObject blackScreen;
    public CameraController cameraController;

    public string gameIntroPath;
    public string gameIntroPath2;

    public RunTutorial tutorialSection;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(true);

        StartCoroutine(BeginGame());
    }

    IEnumerator BeginGame()
    {
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(gameIntroPath)));
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(.1f);

        character.StopCharacter();
        yield return StartCoroutine(cameraController.MoveCamera(new Vector3(0, 2, -10), 7 * Time.deltaTime));
        yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(0, 3.5f), "s", 0.01f));
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(gameIntroPath2)));
        character.StopCharacter();
        yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(0, 10f), "n", 7 * Time.deltaTime));
        wallacesFriend.gameObject.SetActive(false);
        yield return StartCoroutine(cameraController.ResetCamera());
        character.canMove = true;

        StartCoroutine(tutorialSection.Tutorial());
        StopCoroutine(BeginGame());
    }
}
