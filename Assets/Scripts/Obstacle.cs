using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public Transform spawnPoint;

    public bool canGo = false;

    private void Start()
    {

    }

    void Update()
    {
        if (canGo)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        this.gameObject.transform.position = spawnPoint.gameObject.transform.position;
        canGo = false;
    }
}
