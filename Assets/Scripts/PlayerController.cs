using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager m;
    public bool inBlackHole;
    public bool inAnotherBlackHole;
    public bool onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWithGravity();

        if (onPlatform) // Can only change gravity if you are on a platform
        {
            ChangeGravity();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            m.RestartLevel();
        }
    }

    public void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            m.SetGravityUp();
            onPlatform = false;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m.SetGravityLeft();
            onPlatform = false;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            m.SetGravityDown();
            onPlatform = false;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m.SetGravityRight();
            onPlatform = false;
        }
    }
    private void RotateWithGravity()
    {
        if (m.gravUp)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (m.gravDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (m.gravLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (m.gravRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onPlatform = true;
        }
    }
}
