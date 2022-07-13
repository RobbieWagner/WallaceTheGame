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
        hatsParent.SetActive(true);

        yield return new WaitForSeconds(1f);

        StopCoroutine(HatsSection());
    }
}
