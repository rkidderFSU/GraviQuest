using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gravityMultiplier;
    public Vector2 gravityLeft = new Vector2(-9.81f, 0);
    public Vector2 gravityRight = new Vector2(9.81f, 0);
    public Vector2 gravityUp = new Vector2(0, 9.81f);
    public Vector2 gravityDown = new Vector2(0, -9.81f);

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = gravityDown * gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
