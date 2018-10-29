using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullUp : MonoBehaviour {

    float startY;
    [SerializeField] float pullUpForce = 10f;

	// Use this for initialization
	void Start () {
        startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (transform.position.y < startY)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * pullUpForce);
        }
    }
}
