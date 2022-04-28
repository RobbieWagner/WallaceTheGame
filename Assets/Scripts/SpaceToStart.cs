using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToStart : MonoBehaviour
{

    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
