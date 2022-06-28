using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedGirder : MonoBehaviour
{

    public GirderButton button;

    void OnCollisionEnter2D(Collision2D collision)
    {
        button.resetMechanism();
    }
}
