using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class ResetLevel : MonoBehaviour , IPointerClickHandler
{

    // Use this for initialization
    public void OnPointerClick(PointerEventData data)
    {
        // reload the scene
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
