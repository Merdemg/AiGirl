using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour {

    public int Health = 10;
    float counter = 0;
    [SerializeField] float shootCoolDown = 2.5f;
    [SerializeField] GameObject bullet;
    [SerializeField] float shootSpeed = 1000;
    [SerializeField] Transform shootPos;

    [SerializeField] float minJumpTime = 2.5f;
    [SerializeField] float maxJumpTime = 4.5f;
    [SerializeField] float jumpForce = 500f;
    float jumpTimeActual;
    float jumpTimer = 0;

    GameObject player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>().gameObject;
        jumpTimeActual = Random.Range(minJumpTime, maxJumpTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (counter < shootCoolDown)
        {
            counter += Time.deltaTime;
        }
        else if (counter >= shootCoolDown)
        {
            counter -= shootCoolDown;
            shoot();
        }

        if (jumpTimer < jumpTimeActual)
        {
            jumpTimer += Time.deltaTime;
        }
        else
        {
            jumpTimer = 0;
            jumpTimeActual = Random.Range(minJumpTime, maxJumpTime);
            jump();
        }
        
    }

    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(jumpForce * transform.up);
    }

    void shoot()
    {
        GameObject bul = Instantiate(bullet, shootPos.position, Quaternion.identity);
        Vector2 dir = player.transform.position - this.transform.position;
        dir.Normalize();
        bul.GetComponent<Rigidbody2D>().AddForce(dir * shootSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Crate")
        {
            Destroy(collision.gameObject);
            Health--;

            if (Health <= 0)
            {   // MAGIC NUM< FIX LATER
                Application.LoadLevel(2);
                //Destroy(this.gameObject, 0.001f);
            }

        }
        
    }
}
