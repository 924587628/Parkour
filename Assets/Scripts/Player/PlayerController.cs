using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    //private GameManager gameManager;

    private Vector2 boxSize;

    public float jumpForce = 5f;
    private bool IsGround = true;
    private bool canJump = true;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        boxSize = boxCollider.size;
	}
	
	// Update is called once per frame
	void Update () {
        //float v = Input.GetAxis("Vertical");

        //控制跳跃
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jump", true);
            IsGround = false;
            canJump = false;
            animator.SetBool("DoubleJump", false);
        }


        if (Input.GetKey(KeyCode.DownArrow) && IsGround)
        {
            animator.SetBool("Slide", true);
            boxCollider.size = new Vector2(1, 0.5f);

        }
        else
        {
            animator.SetBool("Slide", false);
            boxCollider.size = boxSize;
        }

        if (transform.position.x <= -6.5f)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(-4.5f, transform.position.y), Time.deltaTime);
        }
        
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            canJump = true;
            IsGround = true;
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
        }

        if (coll.gameObject.tag == "UpCollider")
        {
            canJump = true;
            rigidbody.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jump", true);
            animator.SetBool("DoubleJump",true);
            GameObject.Destroy(coll.transform.parent.gameObject);
        }

        if (coll.gameObject.tag == "EnemyBarrier")
        {
         
            GameManager.Instance.GameOver();

        }

        //if (coll.gameObject.tag == "Surfboard")
        //{
        //    animator.SetBool("Slide", true);
        //}
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bonus1")
        {
            GameManager.Instance.UpdateBonus(1);
            //gameManager.UpdateBonus(1);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Bonus2")
        {
            GameManager.Instance.UpdateBonus(5);
            //gameManager.UpdateBonus(5);
            Destroy(coll.gameObject);
        }
    }
}
