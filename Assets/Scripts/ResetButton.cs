using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{

    public GameObject controller;

    private WinConditions script;

    // Start is called before the first frame update
    void Start()
    {
        script = controller.GetComponent<WinConditions>();
    }

    void OnMouseDown() {

        ResetIngredients();

        script.addedIngredients = new List<string>();
    }


    public void ResetIngredients() {

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects) {
            if (obj.name.Contains("(Clone)") && !obj.name.Contains("Equation")) {
                Destroy(obj);
            }
        }
    }
}
