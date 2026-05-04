using UnityEngine;

public class ScrollEngine : MonoBehaviour
{
    SectionAPPARATE ApparaTor;

    private void Start()
    {
        ApparaTor = GameObject.FindFirstObjectByType<SectionAPPARATE>();
    }

    private void OnTriggerExit(Collider other)
    {
        ApparaTor.SpawnTile();
        Destroy(gameObject, 2);
    }
}
