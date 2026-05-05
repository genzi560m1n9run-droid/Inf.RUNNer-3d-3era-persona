using UnityEngine;

public class ScrollEngine : MonoBehaviour
{
    SectionAPPARATE ApparaTor;

    private void Start()
    {
        ApparaTor = GameObject.FindFirstObjectByType<SectionAPPARATE>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        ApparaTor.SpawnTile();
        Destroy(gameObject, 2);
    }

    public GameObject Obstaca; 

    void SpawnObstacle()
    {
        //Chosing were to spawn 
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //Spawning said obstacle

        Instantiate (Obstaca, spawnPoint.position , Quaternion.identity, transform);
    }
}
