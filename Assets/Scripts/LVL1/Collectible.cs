using UnityEngine;
using UnityEngine.Playables;

public class Collectible : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed = 5f;
    
    


    private void Start()
    {
       
        target = GameObject.FindWithTag("CoinEnd1").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }
}
