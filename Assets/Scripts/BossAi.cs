using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour {

    public int Health = 10;
    float counter = 0;
    [SerializeField] float shootCoolDown = 2.5f;
    [SerializeField] GameObject bullet;
    [SerializeField] float shootSpeed = 1000;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (counter < shootCoolDown)
        {
            counter += Time.deltaTime;
        }
        else if (counter >= shootCoolDown)
        {
            counter = 0;
            shoot();
        }
    }

    void shoot()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Crate")
        {
            Destroy(collision.gameObject);
            Health--;
        }
        
    }
}
