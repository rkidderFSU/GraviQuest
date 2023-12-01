using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    private Vector2 startPos;
    public Vector2 destination;
    public float travelTime;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        Vector2.MoveTowards(startPos, destination, 1);
        yield return new WaitForSeconds(1);
        Vector2.MoveTowards(destination, startPos, 1);
        yield return new WaitForSeconds(1);
        StartCoroutine(Move());
    }
}
