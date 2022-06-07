using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{

    public string hazardImmunityGranted;

    // whether or not the hat lets the player open steel doors
    public bool grantsCanOpenDoors;

    public Character character;

    public GameObject hatObjectOnCharacter;
    public GameObject hatsParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D colliderEvent)
    {
        if(colliderEvent.gameObject.CompareTag("Player"))
        {
            character.LoseHat();

            character.hazardTypeImmunity = hazardImmunityGranted;

            if(grantsCanOpenDoors)
            {
                character.canOpenDoors = true;
            }

            foreach(Transform hat in hatsParent.transform) hat.gameObject.SetActive(true);
            gameObject.SetActive(false);

            hatObjectOnCharacter.SetActive(true);
        }
    }
}
