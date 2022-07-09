using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameOpening : MonoBehaviour
{

    public Character character;
    public GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(true);

        //Dialogue plays (StartCoroutine(FirstDialouge()) return yield StartCoroutine(ReadDialouge())  blackScreen.SetActive(false); ReadDialogue(WALLACE! WAKE UP!); Move Wallaces friend
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
