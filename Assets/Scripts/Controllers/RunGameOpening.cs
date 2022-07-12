using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunGameOpening : MonoBehaviour
{

    public Character character;
    public Friend wallacesFriend;
    public GameObject blackScreen;
    public CameraController cameraController;

    public string gameIntroPath;
    public string gameIntroPath2;

    public GameObject wasdControls;
    bool hasMoved;

    // Start is called before the first frame update
    void Start()
    {
        wasdControls.SetActive(false);
        blackScreen.SetActive(true);
        hasMoved = false;

        StartCoroutine(BeginGame());
    }

    void Update()
    {
        if(character.canMove &&(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))) hasMoved = true;
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
        yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(0, 10f), "n", 7 * Time.deltaTime));
        wallacesFriend.gameObject.SetActive(false);
        cameraController.ResetCamera();

        yield return new WaitForSeconds(.25f);
        character.canMove = true;

        wasdControls.SetActive(true);
        
        while(!hasMoved)
        {
            yield return new WaitForSeconds(.25f);
        }

        wasdControls.SetActive(false);
        
        StopCoroutine(BeginGame());
    }
}
