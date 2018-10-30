using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copier : MonoBehaviour {
    PlayerController pController;
    [SerializeField] bool isCutter = false;
	// Use this for initialization
	void Start () {
        pController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Uncopiable")
        {

            if (collision.transform.GetComponent<Platform>() && collision.transform.GetComponentInChildren<PlayerController>())
            {   // DONT COPY THE PLAYER WITH THE PLATFORM
                pController.gameObject.transform.parent = null;
            }

            pController.setObjToCopy(collision.gameObject, isCutter);

            if (collision.transform.GetComponent<Platform>() && collision.transform.GetComponentInChildren<PlayerController>())
            {   // DONT COPY THE PLAYER WITH THE PLATFORM
                pController.gameObject.transform.parent = collision.transform;
            }


            if (collision.transform.tag == "Projectile")
            {
                pController.setSavedVelocity(collision.transform.GetComponent<Rigidbody2D>().velocity);
            }

            pController.setRotation(collision.transform.rotation);
            pController.setSavedScale(collision.transform.localScale);
            if (isCutter)
            {
                collision.gameObject.SetActive(false);
            }
            if (collision.transform.tag == "Crate")  // AVI'S NOOB SHIT< COME BACK LATER
            {
                collision.gameObject.SetActive(false);

            }
        }

        Destroy(this.gameObject);
    }

    public void setCutter(bool cut)
    {
        isCutter = cut;
    }

}
