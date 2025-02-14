using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float jumpForce = 12f;

    private bool grounded = true;

    [SerializeField] private GameManager gm;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        } else if (collision.gameObject.tag == "Obstacle")
        {
            gm.EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }
}
