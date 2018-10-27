using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {

    public float Delay = 2;
    public float DelayTimer;

    public Transform Crate;

    public Transform CratePrefab;

	// Use this for initialization
	void Start () {
        DelayTimer = Delay;
	}
	
	// Update is called once per frame
	void Update () {
		if(Crate == null||Crate.gameObject.activeInHierarchy == false )
        {
            DelayTimer -= Time.deltaTime;
            if(DelayTimer <= 0)
            {
                Crate =  Instantiate(CratePrefab, transform.position, transform.rotation);
                DelayTimer = Delay;
            }

        }
	}
}
