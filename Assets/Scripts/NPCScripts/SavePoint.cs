using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SavePoint : MonoBehaviour
{
    public float positionX;
    public float positionY;

    public GameObject savePointTextGO;
    public TMP_Text savePointTextBox;
    public string savePointText;

    public IEnumerator SavePointReached()
    {
        savePointTextBox.text = savePointText;
        savePointTextGO.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        savePointTextGO.SetActive(false);
        StopCoroutine(SavePointReached());
    }
}
