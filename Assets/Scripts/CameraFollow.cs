using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Playerbody;
    Vector3 offset; 

    private void Start()
    {
        offset= transform.position - Playerbody.position;
    }

    
    private void Update()
    {
        transform.position = Playerbody.position + offset;
    }
}
