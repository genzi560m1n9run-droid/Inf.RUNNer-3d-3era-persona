using UnityEngine;

public class ObstacleSetback : MonoBehaviour
{
    PlayerGoverner PlayerMovin;
    void Start()
    {
        PlayerMovin = GameObject.FindFirstObjectByType<PlayerGoverner>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Player")) 
        {
            if (PlayerMovin != null)
            {
             PlayerMovin.Died();
            }
            

        }
    }
      
}
