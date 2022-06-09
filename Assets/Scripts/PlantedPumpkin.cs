using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantedPumpkin : MonoBehaviour
{

    public Character character;
    private bool playerIsTouching;
    public int pumpkinHealth;
    public Rigidbody2D body;
    public GameObject pumpkin;

    public int scoreHandOff;

    public Animator pumpkinAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerIsTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J) && character.canPullIngrainedPumpkins && playerIsTouching)
        {   
            pumpkinHealth--;
            if(pumpkinHealth <= 0)
            {
                Instantiate(pumpkin, gameObject.transform.position, gameObject.transform.rotation);
                gameObject.SetActive(false);
            }
            else StartCoroutine(ShakePumpkin());
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject == character.gameObject) playerIsTouching = true;
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject == character.gameObject) playerIsTouching = false;
    }

    public IEnumerator ShakePumpkin()
    {
        character.canPullIngrainedPumpkins = false;
        character.canMove = false;
        pumpkinAnimator.SetBool("Shaking", true);
        yield return new WaitForSeconds(.4f);
        pumpkinAnimator.SetBool("Shaking", false);
        character.canMove = true;
        character.canPullIngrainedPumpkins = true;
        StopCoroutine(ShakePumpkin());
    }
}
