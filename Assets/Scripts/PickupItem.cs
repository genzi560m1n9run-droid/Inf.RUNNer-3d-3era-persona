using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {   //Check 
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        //Add

        //Yeet
        Destroy(gameObject);
    }
    void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(0,0 , turnSpeed *  Time.deltaTime);
    }
}
