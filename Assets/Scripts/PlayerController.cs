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
    public bool canChangeGravity;
    AudioSource s;
    public AudioClip gravitySound;
    public AudioClip landingSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        s = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWithGravity();

        if (canChangeGravity || rb.velocity == Vector2.zero)
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
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityUp();
            canChangeGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityLeft();
            canChangeGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityDown();
            canChangeGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityRight();
            canChangeGravity = false;
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
            canChangeGravity = true;
            s.PlayOneShot(landingSound, 1.0f);
        }
    }
}
