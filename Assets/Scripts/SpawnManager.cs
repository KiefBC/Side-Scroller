using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPoint;

    private float startDelay = 2f;
    private float repeatRate = 2f;

    List<Obstacles> obstacles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        GameObject obj = Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        Obstacles obs = obj.GetComponent<Obstacles>();
        obstacles.Add(obs);
    }
}
