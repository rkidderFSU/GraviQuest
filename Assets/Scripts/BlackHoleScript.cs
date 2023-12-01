using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    private GameManager m;
    public float blackHoleStrength;
    public float gravityModifer;
    private PlayerController p;
    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        p = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!p.inBlackHole)
        {
            collision.attachedRigidbody.gravityScale *= gravityModifer;
            p.inBlackHole = true;
        }
        else if (p.inBlackHole)
        {
            p.inAnotherBlackHole = true; // Fix for entering multiple black holes at once
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        Vector3 towardsBlackHole = transform.position - collision.transform.position;
        float distance = Vector3.Distance(transform.position, collision.transform.position);
        float radius = GetComponent<CircleCollider2D>().radius;
        rb.AddForce((radius - distance) * blackHoleStrength * m.gravityMultiplier * towardsBlackHole); // Force will get stronger the closer target object is
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!p.inAnotherBlackHole)
        {
            collision.attachedRigidbody.gravityScale = 1;
            p.inBlackHole = false;
        }
        else
        {
            p.inAnotherBlackHole = false;
        }
    }
}
