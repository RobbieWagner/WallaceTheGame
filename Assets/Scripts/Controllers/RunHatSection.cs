using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RunHatSection : MonoBehaviour
{

    public Character character;
    public Transform characterT;

    public string hatsPart1Path;
    public string hatsPart2Path;

    public GameObject hatsParent;

    public GameObject ingrainedPumpkins;

    //Use to make wallace start in a different position upon running
    public Vector2 wallacePosition;

    // skip the first section (used for testing)
    public bool skipTutorial;

    // Start is called before the first frame update
    void Start()
    {
        if(skipTutorial) StartCoroutine(HatsSection());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HatsSection()
    {
        characterT.position = wallacePosition;
        hatsParent.SetActive(true);
        ingrainedPumpkins.SetActive(true);

        yield return new WaitForSeconds(.1f);

        yield return StartCoroutine(character.ReadDialogue(new StreamReader(hatsPart1Path)));

        StopCoroutine(HatsSection());
    }
}
