using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{

    public Animator friendAnimator;
    bool moving;
    bool doneMoving;

    Vector2 destination;
    float step;

    void Start()
    {
        moving = false;
        doneMoving = false;
    }

    void Update()
    {
        if(moving)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, destination, step);
            if(Vector2.Distance(destination, gameObject.transform.position) < step) doneMoving = true;
        }

    }

    public IEnumerator MoveFriend(Vector2 stoppingPlace, string direction, float movingIncrement)
    {
        if(direction.ToLower().Equals("south") || direction.ToLower().Equals("s") || direction.ToLower().Equals("down"))
        {
            friendAnimator.SetBool("Walking Down", true);
        }
        else if(direction.ToLower().Equals("north") || direction.ToLower().Equals("n") || direction.ToLower().Equals("up"))
        {
            friendAnimator.SetBool("Walking Up", true);
        }
        else if(direction.ToLower().Equals("west") || direction.ToLower().Equals("w") || direction.ToLower().Equals("left"))
        {
            friendAnimator.SetBool("Walking Left", true);
        }
        else if(direction.ToLower().Equals("east") || direction.ToLower().Equals("e") || direction.ToLower().Equals("right"))
        {
            friendAnimator.SetBool("Walking Right", true);
        }

        destination = stoppingPlace;
        step = movingIncrement;
        moving = true;

        while(!doneMoving)
        {
            yield return null;
        }

        moving = false;
        doneMoving = false;

        if(friendAnimator.GetBool("Walking Down")) friendAnimator.SetBool("Walking Down", false);
        if(friendAnimator.GetBool("Walking Up")) friendAnimator.SetBool("Walking Up", false);        
        if(friendAnimator.GetBool("Walking Left")) friendAnimator.SetBool("Walking Left", false);
        if(friendAnimator.GetBool("Walking Right")) friendAnimator.SetBool("Walking Right", false);

        yield return new WaitForSeconds(.5f);

        StopCoroutine(MoveFriend(stoppingPlace, direction, movingIncrement));
    }
}
