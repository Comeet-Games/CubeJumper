using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;
    public GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            //jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.GameEnd();
        }

        if (other.gameObject.tag == "PointTag")
        {
            gameManager.score++;
        }
    }
}
