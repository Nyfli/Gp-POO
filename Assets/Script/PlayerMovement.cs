using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference attackAction;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Look Settings")]
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;
    private Animator animator;
    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        attackAction.action.Enable();

        jumpAction.action.started += Jump;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        attackAction.action.Disable();

        jumpAction.action.started -= Jump;
    }

    private void Update()
    {
        animator.SetBool("isJumping", !isGrounded);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();

        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 velocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        rb.linearVelocity = velocity;

        float horizontalSpeed = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;
        animator.SetFloat("Speed", horizontalSpeed);

        PlayerRotationFromCamera();
    }

    private void PlayerRotationFromCamera()
    {
        Vector3 direction = cameraTransform.forward;
        direction.y = 0;
        transform.LookAt(transform.position + direction);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;

        animator.SetBool("isJumping", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
