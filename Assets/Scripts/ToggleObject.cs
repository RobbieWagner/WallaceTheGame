using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public Character character;
    public int scoreMin;

    void Update()
    {
        if(scoreMin != -1 && character.score >= scoreMin) ToggleObjectOff();
    }

    public void ToggleObjectOff()
    {
        gameObject.SetActive(false);
    }

    public void ToggleObjectOn()
    {
        gameObject.SetActive(true);
    }
}
