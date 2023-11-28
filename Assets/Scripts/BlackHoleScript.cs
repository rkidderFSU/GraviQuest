using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    private GameObject player;
    private GameManager m;
    public float blackHoleStrength;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        Vector3 towardsBlackHole = transform.position - collision.transform.position;
        float distance = Vector3.Distance(transform.position, collision.transform.position);
        float radius = GetComponent<CircleCollider2D>().radius;
        rb.AddForce(towardsBlackHole * m.gravityMultiplier * blackHoleStrength * (radius - distance)); // Force will get stronger the closer target object is
    }
}
