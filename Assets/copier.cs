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
        pController.setObjToCopy(collision.gameObject, isCutter);
        if (collision.transform.tag == "Projectile")
        {
            pController.setSavedVelocity(collision.transform.GetComponent<Rigidbody2D>().velocity);
        }

        if (isCutter)
        {
            collision.gameObject.SetActive(false);
        }
        Destroy(this.gameObject);
    }

    public void setCutter(bool cut)
    {
        isCutter = cut;
    }

}
