using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetPrefabProperties : MonoBehaviour
{
    [MenuItem("Tools/Revert Prefab &p")]
    static void RevertPrefab()
    {
        GameObject[] selection = Selection.gameObjects;
        if (selection.Length < 1) return;
        Undo.RegisterCompleteObjectUndo(selection, "Revert Prefab");
        foreach (GameObject go in selection)
        {
            if (PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance)
            {
                PrefabUtility.RevertPrefabInstance(go);
            }
        }
    }
}
