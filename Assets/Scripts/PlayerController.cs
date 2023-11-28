using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager m;

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

        if (rb.velocity == Vector2.zero) // Can only change gravity if you are not moving
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
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m.SetGravityLeft();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            m.SetGravityDown();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m.SetGravityRight();
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
}
