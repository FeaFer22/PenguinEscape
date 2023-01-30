using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerMovementController movementController;
    PlayerSoundController soundController;


    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public bool sprint_input;

    public bool quack_input;

    private void Awake()
    {
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
        HandleQuackingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    private void HandleSprintingInput()
    {
        if (sprint_input)
        {
            movementController.isSprinting = true;
        }
        else
        {
            movementController.isSprinting = false;
        }
    }
    private void HandleQuackingInput()
    {
        if (quack_input)
        {
            quack_input = false;
            soundController.Quack();
        }
    }
}
