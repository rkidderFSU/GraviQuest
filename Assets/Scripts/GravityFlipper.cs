using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravityFlipper : MonoBehaviour
{
    public float interval;
    private GameManager m;
    AudioSource s;
    PlayerController p;
    public AudioClip gravitySound;
    public TextMeshProUGUI intervalText;
    private SpriteRenderer levelBorder;

    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        s = gameObject.GetComponent<AudioSource>();
        p = GameObject.Find("Player").GetComponent<PlayerController>();
        levelBorder = GameObject.Find("Level Border").GetComponent<SpriteRenderer>();
        StartCoroutine(FlipGravity());
    }

    // Update is called once per frame
    private void Update()
    {
        if (m.levelComplete)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator FlipGravity()
    {
        float seconds = interval;
        for (float i = interval; i > 0; i -= Time.deltaTime)
        {
            intervalText.text = seconds.ToString("#.##");
            yield return new WaitForEndOfFrame();
            seconds -= Time.deltaTime;
        }
        if (m.gravUp)
        {
            m.SetGravityDown();
        }
        else if (m.gravDown)
        {
            m.SetGravityUp();
        }
        else if (m.gravRight)
        {
            m.SetGravityLeft();
        }
        else if (m.gravLeft)
        {
            m.SetGravityRight();
        }
        yield return new WaitForSeconds(0.05f);
        p.canChangeGravity = true;
        p.changedGravity = false; // Resets the player's ability to change gravity
        s.PlayOneShot(gravitySound, 1.0f);
        StartCoroutine(FlipGravity());
        StartCoroutine(ChangeBackgroundColor());
    }

    IEnumerator ChangeBackgroundColor()
    {
        levelBorder.color = Color.cyan;
        yield return new WaitForSeconds(0.125f);
        levelBorder.color = Color.white;
    }
}
