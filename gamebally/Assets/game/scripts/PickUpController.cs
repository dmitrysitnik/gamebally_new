using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpController : MonoBehaviour, IPointerClickHandler {
    const float WAIT_TIME = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData data)
    {
        PlayerController.PickUp();
        StartCoroutine(PlayerController.ReturnState(WAIT_TIME));
    }

}
