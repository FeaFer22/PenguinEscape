using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerMovementController movementController;
    //PlayerAnimationManager playerAnimationManager;
    PlayerSoundController soundController;


    public Vector2 movementInput;
    // public Vector2 cameraInput;

    // public float cameraInputX;
    // public float cameraInputY;

    //public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool sprint_input;
    // public bool jump_input;

    public bool quack_input;

    private void Awake()
    {
        // playerAnimationManager = GetComponent<PlayerAnimationManager>();
        movementController = GetComponent<PlayerMovementController>();
        soundController = GetComponent<PlayerSoundController>();
    }

    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();

            playerInput.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerInput.PlayerActions.Sprint.performed += i => sprint_input = true;
            playerInput.PlayerActions.Sprint.canceled += i => sprint_input = false;

            // playerInput.PlayerActions.Jump.performed += i => jump_input = true;

            playerInput.PlayerActions.Quack.performed += i => quack_input = true;
        }

        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        // HandleJumpingInput();
        HandleQuackingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        // cameraInputY = cameraInput.y;
        // cameraInputX = cameraInput.x;

        //moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        //playerAnimationManager.UpdateAnimatorValues(0, moveAmount, playerMovementController.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (sprint_input /*&& moveAmount > 0.5f*/)
        {
            movementController.isSprinting = true;
        }
        else
        {
            movementController.isSprinting = false;
        }
    }

    // private void HandleJumpingInput()
    // {
    //     if (jump_input)
    //     {
    //         jump_input = false;
    //         playerMovementController.HandleJumping();
    //     }
    // }
    private void HandleQuackingInput()
    {
        if (quack_input)
        {
            quack_input = false;
            soundController.Quack();
        }
    }
}
