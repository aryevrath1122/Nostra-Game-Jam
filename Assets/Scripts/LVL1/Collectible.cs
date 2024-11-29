using UnityEngine;
using UnityEngine.Playables;

public class Collectible : MonoBehaviour
{

    [SerializeField] private float speed = 5f;




    private void Start()
    {

        //target = GameObject.FindWithTag("CoinEnd1").transform;
    }

    private void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}