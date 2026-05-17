using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    public bool playingFootSteps = false;
    public float footStepsSpeed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            StopFootsteps();
            return;
        }
        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("isWalking", rb.linearVelocity.magnitude > 0);
        if(rb.linearVelocity.magnitude > 0 && !playingFootSteps)
        {
            StartFootsteps();
        }
        else if(rb.linearVelocity.magnitude == 0)
        {
            StopFootsteps();
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
    void StartFootsteps()
    {
        playingFootSteps = true;
        InvokeRepeating(nameof(PlayFootStep), 0f, footStepsSpeed);
    }
    void StopFootsteps()
    {
        playingFootSteps = false;
        CancelInvoke(nameof(PlayFootStep));
    }
    void PlayFootStep()
    {
        SoundEffectManager.Play("FootStep", true); 
    }
}
