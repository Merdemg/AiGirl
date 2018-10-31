using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.transform.gameObject);
        }
        else if (collision.transform.GetComponent<PlayerController>())
        {
            Destroy(collision.transform.gameObject);
        }
        else if (collision.transform.tag == "Crate")
        {
            Destroy(collision.transform.gameObject, 0.001f);
        }

        Destroy(this.gameObject);
    }
}
