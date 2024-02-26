using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public string scene_name;
    // Start is called before the first frame update

    void OnMouseDown()
    {
        SceneManager.LoadScene(scene_name);
    }
}
