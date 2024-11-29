using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerControls : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 Movement;
    private bool moveUp = false;
    private bool moveDown = false;

    void Update()
    {
        // Reset vertical movement
        Movement = Vector2.zero;

        // Check if moving up or down
        if (moveUp)
        {
            Movement = new Vector2(0, 1);
        }
        else if (moveDown)
        {
            Movement = new Vector2(0, -1);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
    }

    // Methods to be assigned to button events
    public void OnPressUp()
    {
        moveUp = true;
    }

    public void OnReleaseUp()
    {
        moveUp = false;
    }

    public void OnPressDown()
    {
        moveDown = true;
    }

    public void OnReleaseDown()
    {
        moveDown = false;
    }
}
