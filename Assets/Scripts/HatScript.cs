using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{

    public string hazardImmunityGranted;

    public Character character;

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
            gameObject.SetActive(false);
        }
    }
}
