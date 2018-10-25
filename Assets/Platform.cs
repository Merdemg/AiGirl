using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    Vector2 startPos;
    [SerializeField] float MaxMoveInX = 0;
    [SerializeField] float MinMoveInX = 0;
    [SerializeField] float MaxMoveInY = 0;
    [SerializeField] float MinMoveInY = 0;
    [SerializeField] float moveSpeed = 0;
    float currentRelativeX = 0;
    float currentRelativeY = 0;

    bool isXmovementPositive = true;
    bool isYmovementPositive = true;

    bool isMovingInX = false;
    bool isMovingInY = false;

	// Use this for initialization
	void Start () {
        startPos = transform.position;

        if (MaxMoveInX - MinMoveInX > 0.1f)
        {
            isMovingInX = true;
        }
        if (MaxMoveInY - MinMoveInY > 0.1f)
        {
            isMovingInY = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector2 movementV = new Vector2(0, 0);
        if (isMovingInX)
        {
            if (isXmovementPositive)
            {
                movementV += new Vector2(1, 0);
            }
            else
            {
                movementV += new Vector2(-1, 0);
            }
        }

        if (isMovingInY)
        {
            if (isYmovementPositive)
            {
                movementV += new Vector2(0, 1);
            }
            else
            {
                movementV += new Vector2(0, -1);
            }
        }
        //movementV.Normalize();
        movementV *= (moveSpeed * Time.deltaTime);
        //transform.Translate(movementV);
        GetComponent<Rigidbody2D>().AddForce(movementV);

        Vector2 currPos = transform.position;
        Vector2 difference = currPos - startPos;

        if (difference.x > MaxMoveInX)
        {
            isXmovementPositive = false;
        }
        else if (difference.x < MinMoveInX)
        {
            isXmovementPositive = true;
        }
        if (difference.y > MaxMoveInY)
        {
            isYmovementPositive = false;
        }
        else if (difference.y < MinMoveInY)
        {
            isYmovementPositive = true;
        }


    }
}
