using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigid;
    private CircleCollider2D hitbox;
    private bool isGrounded;
    private bool shoot;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
        isGrounded = true;
        shoot = false;
	}
	
	// Update is called once per frame
	void Update () {

        //move left
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-2.5f, rigid.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rigid.velocity = new Vector2(0, 0);
        }
        //move right
        if(Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(2.5f, rigid.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rigid.velocity = new Vector2(0, 0);
        }

        //jump
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.AddForce(new Vector2(0, 8), ForceMode2D.Force);
            }
        }

        //shooting
        if(Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }
        Debug.Log(shoot);
        shoot = false;
        Debug.Log(shoot);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag.Equals("ground"))
        {
            isGrounded = true;
        }

    }

    
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag.Equals("ground"))
        {
            isGrounded = false;
        }
    }
    
    
}
