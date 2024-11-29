using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // [SerializeField] private GameObject target;
    [SerializeField] private float speed = 5f;


    private void Start()
    {
        
    }

    private void Update()
    {
        
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }
    // Handle collision with the player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}