using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    GameManager m;
    AudioSource sound;
    public AudioClip levelCompleteSound;

    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m.levelComplete = true;
            sound.PlayOneShot(levelCompleteSound, 1.0f);
            yield return new WaitForSeconds(3.0f);
            m.LoadNextLevel();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.attachedRigidbody.velocity *= 0.1f;
        }
    }
}
