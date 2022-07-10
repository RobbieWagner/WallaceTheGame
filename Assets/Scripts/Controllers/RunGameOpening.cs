using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunGameOpening : MonoBehaviour
{

    public Character character;
    public Friend wallacesFriend;
    public GameObject blackScreen;

    public string gameIntroPath;
    public string gameIntroPath2;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(true);

        StartCoroutine(BeginGame());

        //Dialogue plays (StartCoroutine(FirstDialouge()) return yield StartCoroutine(ReadDialouge())  blackScreen.SetActive(false); ReadDialogue(WALLACE! WAKE UP!); Move Wallaces friend
    }

    IEnumerator BeginGame()
    {
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(gameIntroPath)));
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(.1f);

        yield return StartCoroutine(wallacesFriend.MoveFriend(new Vector2(0, 6.5f), "s", 0.1f));
        yield return StartCoroutine(character.ReadDialogue(new StreamReader(gameIntroPath2)));
        
        StopCoroutine(BeginGame());
    }
}
