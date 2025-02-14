using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float speed = 25.0f;

    private float xBoundary = -20f;

    void Update()
    {
        Vector3 movement = Vector3.left * Time.deltaTime * speed;
        rb.MovePosition(movement + transform.position);
    }

    void FixedUpdate()
    {
        if (transform.position.x < xBoundary)
        {
            Destroy(this.gameObject);
        }
    }
}
