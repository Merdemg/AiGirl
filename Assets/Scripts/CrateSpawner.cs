using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {

    [SerializeField] float delayMin = 1.5f;
    [SerializeField] float delayMax = 3f;
    public float DelayTimer;

    public Transform Crate;

    public Transform CratePrefab;

    float spawnActual;

	// Use this for initialization
	void Start () {
        DelayTimer = Random.Range(delayMin, delayMax);
	}
	
	// Update is called once per frame
	void Update () {
		if(Crate == null||Crate.gameObject.activeInHierarchy == false )
        {
            DelayTimer -= Time.deltaTime;
            if(DelayTimer <= 0)
            {
                Crate =  Instantiate(CratePrefab, transform.position, transform.rotation);
                DelayTimer = Random.Range(delayMin, delayMax); ;
            }

        }
	}
}
