using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{

    public Animator friendAnimator;

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

        while(Vector2.Distance(gameObject.transform.position, stoppingPlace) >= movingIncrement);
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, stoppingPlace, movingIncrement);
            yield return new WaitForSeconds(.01f);
        }

        if(friendAnimator.GetBool("Walking Down")) friendAnimator.SetBool("walking Down", false);
        if(friendAnimator.GetBool("Walking Up")) friendAnimator.SetBool("walking Up", false);        
        if(friendAnimator.GetBool("Walking Left")) friendAnimator.SetBool("walking Left", false);
        if(friendAnimator.GetBool("Walking Right")) friendAnimator.SetBool("walking Right", false);
        StopCoroutine(MoveFriend(stoppingPlace, direction, movingIncrement));
    }
}
