using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour {
    [SerializeField] float minVelocityToDie = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vel = collision.relativeVelocity;
        float velY = Mathf.Abs(vel.y);
        Debug.Log("fallspeed: " + velY);
        if (velY >= minVelocityToDie)
        {
            Destroy(this.gameObject, 0.001f);
        }
    }
}
