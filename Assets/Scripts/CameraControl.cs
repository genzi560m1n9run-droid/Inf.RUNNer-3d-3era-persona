
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomLerpSpeed = 10f;
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 15f;

    private Playercontrols controls;
    private CinemachineCamera cam;
    private CinemachineOrbitalFollow orbit;
    private Vector2 scrollDelta;

    private float TargetZoom;
    private float CurrentZoom;

    private Vector3 offset;
    private float currentDistance;



    void Start()
    {
      controls = new Playercontrols();
      controls.Enable();
      controls.CameraControls.MouseZoom.performed += HandleMouseScroll;
        
        Cursor.lockState = CursorLockMode.Locked;
        //cam = GetComponent<CinemachineCamera>();
        //orbit = cam.GetComponent<CinemachineOrbitalFollow>();
        //TargetZoom = CurrentZoom = orbit.Radius;

        if (player != null)
        {
            offset = transform.position - player.position;
            offset.x = 0f;                    
            currentDistance = -offset.z;
        }

    }

    private void HandleMouseScroll(InputAction.CallbackContext context)
    {
        scrollDelta =context.ReadValue<Vector2>();
        Debug.Log($"Doomscrolling  . Value= {scrollDelta}");
    }

    void Update()
    {
        if (player == null) return;

        /*
         if (scrollDelta.y != 0)
         {
             if (orbit != null)
             {
               TargetZoom = Mathf.Clamp(orbit.Radius - scrollDelta.y *zoomSpeed , minDistance, maxDistance);
                 scrollDelta = Vector2.zero;
             }
         }

         CurrentZoom = Mathf.Lerp(CurrentZoom, TargetZoom, Time.deltaTime * zoomLerpSpeed);
         orbit.Radius = CurrentZoom;
        */
        offset.z = -currentDistance;

        Vector3 targetPos = player.position + offset;
        targetPos.x = 0f;

        transform.position = targetPos;
        // Camera lock to player
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }



}
