using UnityEngine;

public class SectionAPPARATE : MonoBehaviour
{
    [SerializeField] int ApparitionDistance;
    public GameObject Stage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("APPARATE") )
        {
            Instantiate(Stage ,new Vector3( 0, 0 ,ApparitionDistance), Quaternion.identity);

        }
    }
}
