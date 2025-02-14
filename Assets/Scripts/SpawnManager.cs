using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPoint;

    private float startDelay = 2f;
    private float repeatRate = 2f;

    List<Obstacles> obstacles;

    void Awake()
    {
        obstacles = new List<Obstacles> ();
    }

    private void OnEnable()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void OnDisable()
    {
        CancelInvoke();

        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] != null)
            {
                obstacles[i].enabled = false;
            }
        }
    }

    void SpawnObstacle()
    {
        GameObject obj = Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        Obstacles obs = obj.GetComponent<Obstacles>();
        obstacles.Add(obs);
    }

    public void DestroyObstacles()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] != null)
            {
                Destroy(obstacles[i].gameObject);
            }
        }

        obstacles.Clear();
    }
}
