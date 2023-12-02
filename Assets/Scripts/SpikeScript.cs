using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    private GameManager m;
    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // "Kills" the player if they collide with a spike
    {
        if (collision.gameObject.CompareTag("Player") && !m.levelComplete)
        {
            m.RestartLevel();
        }
    }
}
