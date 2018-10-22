using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float maxJumpForceTime = 0.6f;
    float jumpCounter = 0;
    

    [SerializeField] GameObject bullet;
    [SerializeField] float shootForce;
    Transform targetPos;

    Rigidbody2D body;
    bool isGrounded = true;
    [SerializeField] Transform bottomPos;
    public LayerMask mask;
    Vector3 direction = new Vector3(0, 0, 0);


    [SerializeField] GameObject copiedObj;
    bool hasCut = false;

    [SerializeField] bool isCutMode = false;
    

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        targetPos = FindObjectOfType<target>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        direction =  new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
        }

        if (Input.GetMouseButtonDown(0) && !hasCut)
        {
            shoot();          
        }

        if (Input.GetMouseButton(1) && copiedObj)
        {
            paste();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isGrounded = groundCheck();
            if (groundCheck())
            {
                jumpCounter = 0;
            }
            else
            {
                jumpCounter = maxJumpForceTime;
            }
        }
        if (Input.GetKey(KeyCode.Space) && jumpCounter <= maxJumpForceTime)
        {
            jumpCounter += Time.deltaTime;
            jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            copiedObj = null;
            isCutMode = !isCutMode;
        }
    }
    public void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(bottomPos.position, 0.05f);
        Vector3 size = new Vector3(1, 0.05f, 1);
        Gizmos.DrawWireCube(bottomPos.position, size);
    }
    private void FixedUpdate()
    {        
        body.AddForce(direction * moveSpeed);
    }

    bool groundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(bottomPos.position, new Vector2(1, 0.05f), 0f, mask);
        if (colliders.Length > 0)
        {
            return true;
        }
        return false;
    }

    void jump()
    {
        
            body.AddForce(transform.up * jumpForce);
        
    }

    void shoot()
    {
        GameObject obj = Instantiate(bullet, this.transform.position, transform.rotation);
        obj.GetComponent<copier>().setCutter(isCutMode);

        Vector3 dir = targetPos.position - this.transform.position;
        dir.Normalize();
        obj.GetComponent<Rigidbody2D>().AddForce(dir * shootForce);
    }

    void paste()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider == null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            GameObject obj = Instantiate(copiedObj, mousePos, transform.rotation);
            obj.SetActive(true);

            copiedObj = null;
            hasCut = false;
        }

        
    }

    public void setObjToCopy(GameObject obj, bool cut)
    {
        copiedObj = obj;
        hasCut = cut;
    }
}
