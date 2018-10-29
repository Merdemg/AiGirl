using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour {
    [SerializeField] LayerMask myMask;
    GameObject player;

    float counter = 0;
    [SerializeField] float shootCoolDown = 2.5f;
    [SerializeField] GameObject bullet;
    [SerializeField] float maxShootDistance = 10f;
    [SerializeField] float shootSpeed = 1000;
    [SerializeField] Transform left, right;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (counter < shootCoolDown)
        {
            counter += Time.deltaTime;
        }
        else if (counter >= shootCoolDown && checkPlayerVisibiliy() && Vector2.Distance(this.transform.position, player.transform.position) <= maxShootDistance)
        {
            counter = 0;
            shoot();
        }
	}


    bool checkPlayerVisibiliy()
    {
        Debug.DrawRay(player.transform.position, this.transform.position - player.transform.position, Color.red);
        // Debug.Log(Physics2D.Raycast(player.transform.position, this.transform.position - player.transform.position, myMask).transform.gameObject);
        Debug.Log(player.transform.position);
        if (Physics2D.Raycast(player.transform.position, this.transform.position - player.transform.position, Mathf.Infinity, myMask))
        {
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, this.transform.position - player.transform.position, Mathf.Infinity, myMask);
            
            Debug.Log("raycast hit: " + hit.transform.gameObject);
            if (hit.transform.gameObject == this.gameObject)
            {
                Debug.Log("player visible");
                return true;
            }
        }
        Debug.Log("player NOT visible");
        return false;
    }

    void shoot()
    {
        Debug.Log("shooting!");

        Vector2 pos;
        if (player.transform.position.x - this.transform.position.x > 0)
        {
            pos = right.transform.position;
        }
        else
        {
            pos = left.transform.position;
        }
        GameObject bul = Instantiate(bullet, pos, transform.rotation);
        Vector2 dir = player.transform.position - this.transform.position;
        dir.Normalize();
        bul.GetComponent<Rigidbody2D>().AddForce(dir * shootSpeed);
    }

}

/*
 * Debug.DrawRay(this.transform.position, positions[i].position - this.transform.position, Color.red);
            if(Physics2D.Raycast(this.transform.position, positions[i].position - this.transform.position, rayDistance, playerMask))
            {
                RaycastHit2D temp = Physics2D.Raycast(this.transform.position, positions[i].position - this.transform.position, rayDistance, playerMask);
                if (temp.transform.tag == "Ghost")
                {
                    ghost = temp.transform.gameObject;
                    return true;
                }
            }
 * 
 * 
 * 
 * 
 * */
