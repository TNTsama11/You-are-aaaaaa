using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowMouse : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    public bool isFollow = false;
    public bool isGrab = false;

    void Awake()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (transform.position.y < -4)
        {
            isFollow = false;
            myRigidbody.gravityScale = 1;
            this.transform.position = new Vector3(transform.position.x, -4, 0);
        }
        if (transform.position.x < -8)
        {
            isFollow = false;
            myRigidbody.gravityScale = 1;
            this.transform.position = new Vector3(-7.8f, transform.position.y, 0);
        }
        if (transform.position.x > 8)
        {
            isFollow = false;
            myRigidbody.gravityScale = 1;
            this.transform.position = new Vector3(7.8f, transform.position.y, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;
            hit=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.gameObject == this.gameObject&&!isGrab)
                {
                myRigidbody.gravityScale = 0;
                    isFollow = true;
                }         
        }

        if (Input.GetMouseButtonUp(0)&&isFollow&&!isGrab)
        {
            myRigidbody.gravityScale = 1;
            isFollow = false;
        }

        if (isFollow)
        {
            Vector3 temp= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(temp.x, temp.y, 0),0.2f);
        }


    }
}
