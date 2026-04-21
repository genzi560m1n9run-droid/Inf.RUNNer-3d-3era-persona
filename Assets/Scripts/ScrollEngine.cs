using UnityEngine;

public class ScrollEngine : MonoBehaviour
{
    [SerializeField] int ScrollSped = 4; 
    void Update()
    {
        transform.position += new Vector3(0, 0, ScrollSped) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YEET"))
        {
            Destroy(gameObject);
        }
    }
}
