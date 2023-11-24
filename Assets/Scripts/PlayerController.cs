using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGravity();
    }

    public void ChangeGravity()
    {
        if (rb.velocity == Vector2.zero) // Can only change gravity if you are not moving
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Physics2D.gravity = manager.gravityUp * manager.gravityMultiplier;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Physics2D.gravity = manager.gravityLeft * manager.gravityMultiplier;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Physics2D.gravity = manager.gravityDown * manager.gravityMultiplier;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Physics2D.gravity = manager.gravityRight * manager.gravityMultiplier;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
    }
}
