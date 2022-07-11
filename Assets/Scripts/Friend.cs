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
            if(step < .1f) step = .1f;
            gameObject.transform.position = Vector2.MoveTowards(destination, gameObject.transform.position, step);
            if(Vector2.Distance(destination, gameObject.transform.position) < step) doneMoving = true;
        }

    }

    public IEnumerator MoveFriend(Vector2 stoppingPlace, string direction, float movingIncrement)
    {
        Debug.Log("Move Friend Running");
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
        bool moving = true;

        while(!doneMoving)
        {
            yield return null;
        }

        moving = false;
        doneMoving = false;

        if(friendAnimator.GetBool("Walking Down")) friendAnimator.SetBool("walking Down", false);
        if(friendAnimator.GetBool("Walking Up")) friendAnimator.SetBool("walking Up", false);        
        if(friendAnimator.GetBool("Walking Left")) friendAnimator.SetBool("walking Left", false);
        if(friendAnimator.GetBool("Walking Right")) friendAnimator.SetBool("walking Right", false);

        yield return new WaitForSeconds(.5f);

        StopCoroutine(MoveFriend(stoppingPlace, direction, movingIncrement));
    }
}
