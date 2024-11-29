using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 10f;
    [SerializeField] Rigidbody2D rb;
    Vector2 Movement;


    // Update is called once per frame
    void Update()
    {

        float vert = Input.GetAxisRaw("Vertical");

        Movement = new Vector2(0, vert);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
    }
}