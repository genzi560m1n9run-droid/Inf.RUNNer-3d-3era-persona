using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerGoverner : MonoBehaviour
{
    //[SerializeField] private Transform cameraTransform;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private bool shouldFaceMoveDirection=false;
    [SerializeField] private float horizontalMultiplier = 2f;

    private CharacterController governer;
    private Vector3 moveInput;
    private Vector3 velocity;

    void Start()
    {
        governer = GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input:{moveInput} ");
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping{context.performed} - Is Grounded :{governer.isGrounded} ");
        if (context.performed && governer.isGrounded)
        {
            Debug.Log("We are supposed to jump");
            velocity.y =  Mathf.Sqrt (jumpHeight * -2f * gravity);
        }
    }

    void Update()
    {  /*
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        governer.Move(moveDirection*speed*Time.deltaTime);
        */ 

        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;                    
        Vector3 horizontalMove = transform.right * moveInput.x * speed * Time.deltaTime * horizontalMultiplier;  

        governer.Move(forwardMove + horizontalMove);

        /*
        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude> 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation( moveDirection , Vector3.up );
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation,10 * Time.deltaTime);
        }
        */
        if (shouldFaceMoveDirection && moveInput.sqrMagnitude > 0.001f)
        {
            Vector3 moveDirection = forwardMove + horizontalMove;   
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10 * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        governer.Move(velocity * Time.deltaTime);
    }



}