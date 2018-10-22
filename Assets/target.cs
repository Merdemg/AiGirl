using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
    Vector3 mousePos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
	}
}
