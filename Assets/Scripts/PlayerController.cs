using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        RotateWithGravity();

        if (rb.velocity == Vector2.zero) // Can only change gravity if you are not moving
        {
            ChangeGravity();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            manager.SetGravityUp();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            manager.SetGravityLeft();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            manager.SetGravityDown();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            manager.SetGravityRight();
        }
    }
    private void RotateWithGravity()
    {
        if (manager.gravUp)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (manager.gravDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (manager.gravLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (manager.gravRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
