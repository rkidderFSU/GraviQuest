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
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        s = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWithGravity();
        ChangeColor();

        if ((canChangeGravity || rb.velocity == Vector2.zero) && !m.levelComplete)
        {
            ChangeGravity();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            m.RestartLevel();
        }
    }

    private void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityUp();
            canChangeGravity = false;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityLeft();
            canChangeGravity = false;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityDown();
            canChangeGravity = false;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityRight();
            canChangeGravity = false;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
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
    private void ChangeColor()
    {
        if (canChangeGravity || ((rb.velocity == Vector2.zero) && !m.levelComplete))
        {
            sr.color = Color.white;
        }
        else if (!canChangeGravity && rb.velocity.magnitude > 0)
        {
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && !m.levelComplete && (rb.velocity.magnitude <= 0.1f))
        {
            canChangeGravity = true;
            sr.color = Color.white;
            if (s.isPlaying)
            {
                s.Stop();
                s.PlayOneShot(landingSound, 1.0f);
            }
            else
            {
                s.PlayOneShot(landingSound, 1.0f);
            }
        }
    }
}
