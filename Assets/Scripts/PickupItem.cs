using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.GetComponent<ObstacleSetback>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //Check 
        if (other.CompareTag("Player"))
        { 
            GameManager.inst.Plus1Score();
            Destroy(gameObject);
        }
        //Add

       
    }
    void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(0,0 , turnSpeed *  Time.deltaTime);
    }
}
