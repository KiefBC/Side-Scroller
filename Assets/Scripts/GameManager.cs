using System.Collections;
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
        Debug.Log("Game Over");
        StartCoroutine(ResetGameAfterDelay());
    }

    private IEnumerator ResetGameAfterDelay()
    {
        Debug.Log("Waiting for 3 seconds");
        yield return new WaitForSeconds(3f);
        Debug.Log("Resetting the game");
        Reset();
    }

    public void Reset()
    {
        sm.DestroyObstacles();
        sm.enabled = true;
        bg.enabled = true;
        pc.Reset();
    }
}
