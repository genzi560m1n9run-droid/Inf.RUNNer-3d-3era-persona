using UnityEngine;

public class SectionAPPARATE : MonoBehaviour
{
    public GameObject TilePod;
    Vector3 NextPodSpawn;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(TilePod, NextPodSpawn , Quaternion.identity);
        NextPodSpawn = temp.transform.GetChild(1).transform.position;
    }
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }
}
