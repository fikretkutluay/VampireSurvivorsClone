using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    private void HandleInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            anim.SetFloat("MoveX", moveInput.x);
            anim.SetFloat("MoveY", moveInput .y);
            anim.SetFloat("Speed", moveInput.sqrMagnitude);
        }

        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            anim.SetBool("IsSide", true);
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", false);
        }
        else
        {
            anim.SetBool("IsSide", false);
            anim.SetBool("IsUp", moveInput.y > 0);
            anim.SetBool("IsDown", moveInput.y < 0);
        }

        if (moveInput.x != 0)
            GetComponent<SpriteRenderer>().flipX = moveInput.x < 0;
    }
}
   
