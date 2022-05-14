using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAndMove : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 22f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;

    private void Awake() {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveKeyboard();
        AnimatePlayer();
        playerJump();
        CheckIfGrounded();
    }
    
    void playerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        if (movementX != 0) {
            Debug.Log("Player has moved" + movementX);
        }

        transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
    }
    
    void AnimatePlayer() {
        if (movementX > 0) {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        } else if (movementX < 0) {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    
    void playerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Player has jumped");
            isGrounded = false;
        }
    }

    void CheckIfGrounded() {
        if (myBody.velocity.y == 0) {
            isGrounded = true;
        }
    }
}
