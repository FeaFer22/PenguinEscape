using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    // Animator animator;
    PlayerInputManager playerInputManager;
    PlayerMovementController playerMovementHandler;
    // CameraManager cameraManager;

    public bool isInteracting;

    private void Awake()
    {
        // animator = GetComponent<Animator>();
        playerInputManager = GetComponent<PlayerInputManager>();
        // cameraManager = FindObjectOfType<CameraManager>();
        playerMovementHandler = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        playerInputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerMovementHandler.HandleAllMovement();
    }

    private void LateUpdate()
    {
        // cameraManager.HandleAllCameraMovement();

        // isInteracting = animator.GetBool("isInteracting");
        // playerMovementHandler.isJumping = animator.GetBool("isJumping");
        // animator.SetBool("isGrounded", playerMovementHandler.isGrounded);
    }
}
