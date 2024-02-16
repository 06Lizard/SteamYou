using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private CharacterController2D controller;

    public float runSpeed = 40f;
    public float dashSpeed = 80f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Jump") && jump)
        {
            dash = true;
            animator.SetBool("IsDashing", true);
        }
    }


   


    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnDashEnd()
    {
    animator.SetBool("IsDashing", false);
    }

private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, dash);
        jump = false;
        dash = false;
    }
}
