using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerGoverner : MonoBehaviour
{
    //[SerializeField] private Transform cameraTransform;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    //[SerializeField] private bool shouldFaceMoveDirection=false;
    [SerializeField] private float horizontalMultiplier = 2f;
    bool aLive = true; 

    private CharacterController governer;
    private Vector3 moveInput;
    private Vector3 velocity;

    void Start()
    {
        governer = GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!aLive) return;
        moveInput = context.ReadValue<Vector2>();
       
    }
    public void OnJump(InputAction.CallbackContext context)
    {   
         if (!aLive) return;
        Debug.Log($"Jumping{context.performed} - Is Grounded :{governer.isGrounded} ");
        if (context.performed && governer.isGrounded)
        {
            Debug.Log("We are supposed to jump");
            velocity.y =  Mathf.Sqrt (jumpHeight * -2f * gravity);
        }
    }

    private void Update()
    {   
        if (!aLive) return;
        float testSpeed = 15f; // fuerza bruta para probar

        Vector3 forwardMove = Vector3.forward * testSpeed * Time.deltaTime;

        // Ignora rotación del jugador para probar
        governer.Move(forwardMove + new Vector3(moveInput.x * 8f * Time.deltaTime, 0, 0));
        /*
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        governer.Move(moveDirection*speed*Time.deltaTime);
        */


        //Vector3 forwardMove = transform.forward * speed * Time.deltaTime;                    
        Vector3 horizontalMove = transform.right * moveInput.x * speed * Time.deltaTime * horizontalMultiplier;  

        //governer.Move(forwardMove + horizontalMove);

        /*
        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude> 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation( moveDirection , Vector3.up );
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation,10 * Time.deltaTime);
        }
       
        if (shouldFaceMoveDirection && moveInput.sqrMagnitude > 0.001f)
        {
            Vector3 moveDirection = forwardMove + horizontalMove;   
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10 * Time.deltaTime);
        }
        */
        velocity.y += gravity * Time.deltaTime;
        governer.Move(velocity * Time.deltaTime);
        if(transform.position.y <-2)
        {
            Died();
        }
    }
    public void Died()
    {
        aLive = false;
        //restart 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}