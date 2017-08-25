using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    private void OnMouseUp()
    {
        Scene scene = SceneManager.GetSceneByName("main");
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void OnMouseEnter()
    {
        
    }
}
