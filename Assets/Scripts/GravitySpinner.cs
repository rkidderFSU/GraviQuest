using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravitySpinner : MonoBehaviour
{
    public int interval;
    private GameManager m;
    AudioSource s;
    PlayerController p;
    public AudioClip gravitySound;
    public TextMeshProUGUI intervalText;

    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        s = gameObject.GetComponent<AudioSource>();
        p = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(RotateGravity());
    }

    // Update is called once per frame
    private void Update()
    {
        if (m.levelComplete)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator RotateGravity()
    {
        int seconds = interval;
        for (int i = interval; i > 0; i--)
        {
            intervalText.text = seconds.ToString();
            yield return new WaitForSeconds(1);
            seconds--;
        }

        if (m.gravUp)
        {
            m.SetGravityRight();
        }
        else if (m.gravDown)
        {
            m.SetGravityLeft();
        }
        else if (m.gravRight)
        {
            m.SetGravityDown();
        }
        else if (m.gravLeft)
        {
            m.SetGravityUp();
        }
        s.PlayOneShot(gravitySound, 1.0f);
        p.canChangeGravity = true;
        StartCoroutine(RotateGravity());
    }
}
