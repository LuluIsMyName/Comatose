using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public ClickToMove()
    {
        // This is a constructor.
    }
    public float speed = 5.0f; 
    private Vector3 targetPosition;
    private bool isMoving = false;
    [SerializeField]
    private Rigidbody2D rb;
    Vector2 mousePos;
    private SpriteRenderer sr;
    private Animator anim;
    public Sprite idle;
    

    private string WALK_ANIMATION = "Walk";
    Vector2 posDif;
    private void Awake() {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {

    }
    void Update()
    {
        AnimatePlayer();
        if (Input.GetMouseButton(0)& Input.GetKey(KeyCode.E))
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            Move();
        }
        Debug.Log(rb.velocity.x);
        
    }
    void SetTargetPosition() 
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }
    void Move() 
    {   
        rb.velocity = (targetPosition - transform.position).normalized * speed;
        if (Vector2.Distance(targetPosition, transform.position) < 0.1f)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }
    }
    void AnimatePlayer() {
        if (rb.velocity.x > 0) {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
            anim.enabled = true;
        } else if (rb.velocity.x < 0) {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
            anim.enabled = true;
        } else {
            sr.sprite = idle;
            anim.enabled = false;
        }
    }
}
