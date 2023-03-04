using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    public float rotationSpeed = 2;
    public float floatingHeight = 0.5f;
    private int count = 0;
    private const int steps = 50;
    private bool up;

    void Start()
    {
        rotationSpeed = Random.Range(0.5f * rotationSpeed, 1.5f * rotationSpeed);
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.inGame) return;
        transform.Rotate(new Vector3(0, 0, rotationSpeed));

        Vector3 moveUp = (up) ? new Vector3(0f, floatingHeight / steps, 0f) : new Vector3(0f, -floatingHeight / steps, 0f);
        transform.position += moveUp;
        count++;
        if (count == steps)
        {
            count = 0;
            up = !up;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
