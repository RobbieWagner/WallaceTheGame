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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HatsSection()
    {
        characterT.position = new Vector2(0,0);
        hatsParent.SetActive(true);

        yield return new WaitForSeconds(.1f);

        yield return StartCoroutine(character.ReadDialogue(new StreamReader(hatsPart1Path)));

        StopCoroutine(HatsSection());
    }
}
