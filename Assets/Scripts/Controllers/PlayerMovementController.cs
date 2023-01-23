using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerInputManager playerInputManager;
    // PlayerAnimationManager animationManager;

    Vector3 moveDirection;
    // Transform cameraObject;

    private Rigidbody playerRigidbody;


    // public float inAirTimer;
    // public float leapingVelocity;
    // public float fallingVelocity;
    // public float rayCastHeightOffset = 0.5f;
    // public LayerMask groundLayer;


    public bool isSprinting;
    // public bool isGrounded;
    // public bool isJumping;

    // public float walkingSpeed = 1.5f;
    public float runningSpeed = 9f;
    public float sprintSpeed = 13f;
    public float rotationSpeed = 15f;

    // public float gravityIntensity = -15f;
    // public float jumpHeight = 3f;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        //animationManager = GetComponent<PlayerAnimationManager>();
        playerInputManager = GetComponent<PlayerInputManager>();  
        playerRigidbody = GetComponent<Rigidbody>();
        //cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        //HandleFallingAndlanding();

        // if (playerManager.isInteracting)
        //     return;

        HandleMovement();
        // HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = /*cameraObject.forward*/ transform.forward * playerInputManager.verticalInput;
        moveDirection = moveDirection + /*cameraObject.right*/ transform.right * playerInputManager.horizontalInput;
        moveDirection = Quaternion.Euler(0,45f,0) * moveDirection;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if(isSprinting)
        {
            moveDirection = moveDirection * sprintSpeed;
        }
        else
        {
            moveDirection = moveDirection * runningSpeed;
            // if (playerInputManager.moveAmount > 0.55f)
            // {
            //     moveDirection = moveDirection * runningSpeed;
            // }
            // else
            // {
            //     moveDirection = moveDirection * walkingSpeed;

            // }
        }

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;

        // if (isGrounded && !isJumping)
        // {
        //     Vector3 movementVelocity = moveDirection;
        //     playerRigidbody.velocity = movementVelocity;
        // }
    }

    private void HandleRotation()
    {
        Vector3 targetDirection;

        targetDirection = transform.forward * playerInputManager.verticalInput;
        targetDirection = targetDirection + transform.right * playerInputManager.horizontalInput;
        targetDirection.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        transform.rotation = targetRotation;
        // Vector3 targetDirection = Vector3.zero;

        // targetDirection = /*cameraObject.forward*/ transform.forward * playerInputManager.verticalInput;
        // targetDirection = targetDirection + /*cameraObject.right*/ transform.right * playerInputManager.horizontalInput;
        // targetDirection.Normalize();
        // targetDirection.y = 0;
        
        // if (targetDirection == Vector3.zero)
        //     targetDirection = transform.forward;


        // if (isJumping)
        //     return;

        // Vector3 targetDirection = Vector3.zero;

        // targetDirection = /*cameraObject.forward*/ transform.forward * playerInputManager.verticalInput;
        // targetDirection = targetDirection + /*cameraObject.right*/ transform.right * playerInputManager.horizontalInput;
        // targetDirection = Quaternion.Euler(0,45f,0) * targetDirection;
        // targetDirection.Normalize();
        // targetDirection.y = 0;
        
        // if (targetDirection == Vector3.zero)
        //     targetDirection = transform.forward;


        //Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        //Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //transform.rotation = targetRotation /*playerRotation*/;
    }

    // private void HandleFallingAndlanding()
    // {
    //     RaycastHit hit;
    //     Vector3 rayCastOrigin = transform.position;
    //     Vector3 targetPosition;
    //     rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;
    //     targetPosition = transform.position;

    //     if (!isGrounded && !isJumping)
    //     {
    //         if (!playerManager.isInteracting)
    //         {
    //             animationManager.PlayTargetAnimation("Falling", true);
    //         }

    //         inAirTimer = inAirTimer + Time.deltaTime;
    //         playerRigidbody.AddForce(transform.forward * leapingVelocity);
    //         playerRigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
    //     }

    //     if (Physics.SphereCast(rayCastOrigin, 0.2f, Vector3.down, out hit, 0.5f, groundLayer))
    //     {
    //         if (!isGrounded && !playerManager.isInteracting)
    //         {
    //             animationManager.PlayTargetAnimation("Landing", true);
    //         }

    //         Vector3 rayCastHitPoint = hit.point;
    //         targetPosition.y = rayCastHitPoint.y;
    //         inAirTimer = 0;
    //         isGrounded = true;
    //         playerManager.isInteracting = false;
    //     }
    //     else
    //     {
    //         isGrounded = false;
    //     }

    //     if (isGrounded && !isJumping)
    //     {
    //         if (playerManager.isInteracting || playerInputManager.moveAmount > 0)
    //         {
    //             transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
    //         }
    //         else
    //         {
    //             transform.position = targetPosition;
    //         }
    //     }
    // }

    // public void HandleJumping()
    // {
    //     if (isGrounded)
    //     {
    //         animationManager.animator.SetBool("isJumping", true);
    //         animationManager.PlayTargetAnimation("Jump", false);

    //         float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
    //         Vector3 playerVelocity = moveDirection;
    //         playerVelocity.y = jumpingVelocity;
    //         playerRigidbody.velocity = playerVelocity;
    //     }
    // }
}


