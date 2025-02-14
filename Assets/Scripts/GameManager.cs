using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Playercontroller pc;
    [SerializeField] private Background bg;
    [SerializeField] private SpawnManager sm;

    public void EndGame()
    {
        bg.enabled = false;
        sm.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
