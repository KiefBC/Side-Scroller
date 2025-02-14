using UnityEngine;

public class Background : MonoBehaviour
{
    private float speed = 25.0f;
    private Vector3 startPos;
    private float halfWidth = 112.8f / 2f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 movement = Vector3.left * Time.deltaTime * speed;
        transform.Translate(movement);

        if (transform.position.x < startPos.x - halfWidth)
        {
            transform.position += new Vector3(halfWidth, 0, 0);
        }
    }
}
