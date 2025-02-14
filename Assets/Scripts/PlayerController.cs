using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float jumpForce = 12f;

    private bool grounded = true;

    [SerializeField] private GameManager gm;

    [SerializeField] private Animator anim;
    private bool dead = false;

    [SerializeField] private ParticleSystem explodeParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dirtParticle.Play();
        } 
        else if (collision.gameObject.tag == "Obstacle")
        {
            explodeParticle.Play();
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashSound);
            gm.EndGame();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            dead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded && !dead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            anim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound);
        }
    }

    public void Reset()
    {
        // Turn off the death animation
        anim.SetBool("Death_b", false);
        anim.SetInteger("DeathType_int", 0);
        dead = false;

        // Disable and re-enable the Animator component
        anim.gameObject.SetActive(false);
        anim.gameObject.SetActive(true);

        Debug.Log("Attempting to reset Animation...");
        anim.Rebind();
        anim.Update(0f);
        grounded = true;
        dirtParticle.Play();
    }


}
