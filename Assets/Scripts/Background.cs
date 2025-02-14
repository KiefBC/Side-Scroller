using UnityEngine;

public class Background : MonoBehaviour
{
    private float speed = 25.0f;
    private float xBoundary = -20f;

    private Vector3 startPos;

    private float halfWidth = 112.8f / 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.left * Time.deltaTime * speed;
        transform.Translate(movement);

        if (transform.position.x < startPos.x - halfWidth)
        {
            transform.position += new Vector3(halfWidth, 0, 0);
        }
    }

    void FixedUpdate()
    {
    }
}
