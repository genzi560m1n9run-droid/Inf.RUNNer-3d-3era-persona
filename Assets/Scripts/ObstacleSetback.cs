using UnityEngine;

public class ObstacleSetback : MonoBehaviour
{
    PlayerGoverner PlayerMovin;
    void Start()
    {
        PlayerMovin = GameObject.FindFirstObjectByType<PlayerGoverner>();

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            PlayerMovin.Died();

        }
    }
}
