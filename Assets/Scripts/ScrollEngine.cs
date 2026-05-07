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

    public GameObject Chapita; 

    void SpawnCoins()
    {
        int coinsPending = 7;
        for (int i = 0; i < coinsPending; i++)
        {
            GameObject temp = Instantiate(Chapita , transform);
            temp.transform.position= GetRandomPointInCollider (GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point =GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;

    }
}
