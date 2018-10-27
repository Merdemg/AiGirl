using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCog : MonoBehaviour {
    public float RotateSpeed = 2.5f;

    public Transform Target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    private void Update()
    {
        this.transform.RotateAround(Target.position, zAxis, RotateSpeed);
    }
}
