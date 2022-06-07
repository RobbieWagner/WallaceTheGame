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
    public GameObject[] hatsOnCharacter;
    public GameObject[] hatsOnGround;

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
            character.hazardTypeImmunity = hazardImmunityGranted;

            if(grantsCanOpenDoors)
            {
                character.canOpenDoors = true;
            }
            else
            {
                character.canOpenDoors = false;
            }

            foreach(GameObject hat in hatsOnGround) hat.SetActive(true);
            gameObject.SetActive(false);

            foreach(GameObject hat in hatsOnCharacter) hat.SetActive(false);
            hatObjectOnCharacter.SetActive(true);
        }
    }
}
