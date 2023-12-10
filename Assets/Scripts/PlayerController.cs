using System.Collections;
using System.Collections.Generic;
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
    private SpriteRenderer sr;
    public bool changedGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        s = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        canChangeGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateWithGravity();
        ChangeColor();

        if (canChangeGravity && !m.levelComplete && !changedGravity)
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
            changedGravity = true;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityLeft();
            canChangeGravity = false;
            changedGravity = true;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityDown();
            canChangeGravity = false;
            changedGravity = true;
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            s.PlayOneShot(gravitySound, 1.0f);
            m.SetGravityRight();
            canChangeGravity = false;
            changedGravity = true;
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
        if (canChangeGravity && !changedGravity)
        {
            sr.color = Color.white;
        }
        else if ((!canChangeGravity || changedGravity) && rb.velocity.magnitude > 0)
        {
            sr.color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && !m.levelComplete && (rb.velocity.magnitude <= 2.0f))
        {
            canChangeGravity = true;
            changedGravity = false;
            if (s.isPlaying)
            {
                s.Stop();
                s.PlayOneShot(landingSound, 1.0f); // to prevent double sound playing if colliding with two platforms at once
            }
            else
            {
                s.PlayOneShot(landingSound, 1.0f);
            }
        }
        else if (collision.gameObject.CompareTag("OWPlatform") && !m.levelComplete && (rb.velocity.magnitude <= 2.0f))
        {
            canChangeGravity = true;
            changedGravity = false;
            if (s.isPlaying)
            {
                s.Stop();
                s.PlayOneShot(landingSound, 1.0f); // to prevent double sound playing if colliding with two platforms at once
            }
            else
            {
                s.PlayOneShot(landingSound, 1.0f);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision) // Wacky platform collision
    {
        if (collision.gameObject.CompareTag("Platform") && !m.levelComplete && (rb.velocity.magnitude <= 0.01f))
        {
            canChangeGravity = true;
            changedGravity = false;
        }
        else if (collision.gameObject.CompareTag("Platform") && !m.levelComplete && (rb.velocity.magnitude > 0.01f) && !changedGravity)
        {
            canChangeGravity = true;
        }
        else if (collision.gameObject.CompareTag("Platform") && !m.levelComplete && (rb.velocity.magnitude > 0.01f) && changedGravity)
        {
            canChangeGravity = false;
        }
        if (collision.gameObject.CompareTag("OWPlatform") && !m.levelComplete && rb.velocity.magnitude == 0)
        {
            canChangeGravity = true;
            changedGravity = false;
        }
        else if (collision.gameObject.CompareTag("OWPlatform") && !m.levelComplete && changedGravity && (rb.velocity.magnitude > 0))
        {
            canChangeGravity = false;
        }
        else if (collision.gameObject.CompareTag("OWPlatform") && !m.levelComplete && !changedGravity)
        {
            canChangeGravity = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OWPlatform") && !m.levelComplete && changedGravity)
        {
            canChangeGravity = false;
        }
    }
}
