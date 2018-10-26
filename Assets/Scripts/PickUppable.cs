using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUppable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            collision.transform.GetComponent<PlayerController>().pickUp();
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("pick up triggr triggered. lol");
        if (collision.transform.GetComponent<PlayerController>())
        {
            collision.transform.GetComponent<PlayerController>().pickUp();
            Destroy(this.gameObject);

        }
    }


}
