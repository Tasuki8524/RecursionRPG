using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool jumpKeyPressed = false;
    private bool crouchKeyPressed = false;
    [SerializeField] private Animator animator;
    private float horizontalInput;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    [SerializeField] CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump")) {
            jumpKeyPressed = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch")) {
            crouchKeyPressed = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouchKeyPressed = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("True");
        if (Input.GetButtonDown("Jump"))
        {
            jumpKeyPressed = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnCrouch(bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouchKeyPressed, jumpKeyPressed);
        
        jumpKeyPressed = false;
    }
}
