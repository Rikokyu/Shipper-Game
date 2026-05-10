using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRideMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    public bool playingRideSound = false;
    public float rideSoundSpeed = 0.5f;

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
            animator.SetBool("isRiding", false);
            StopRideSound();
            return;
        }
        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("isRiding", rb.linearVelocity.magnitude > 0);
        if(rb.linearVelocity.magnitude > 0 && !playingRideSound)
        {
            StartRideSound();
        }
        else if(rb.linearVelocity.magnitude == 0)
        {
            StopRideSound();
        }
    }
    public void Move(InputAction.CallbackContext context)
    {

        animator.SetBool("isRiding", true);

        if (context.canceled)
        {
            animator.SetBool("isRiding", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
        void StartRideSound()
    {
        playingRideSound = true;
        InvokeRepeating(nameof(PlayRideSound), 0f, rideSoundSpeed);
    }
    void StopRideSound()
    {
        playingRideSound = false;
        CancelInvoke(nameof(PlayRideSound));
    }
    void PlayRideSound()
    {
        SoundEffectManager.Play("RideSound", true); 
    }

}
