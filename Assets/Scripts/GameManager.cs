using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gravityMultiplier;
    public Vector2 gravityLeft = new Vector2(-9.81f, 0);
    public Vector2 gravityRight = new Vector2(9.81f, 0);
    public Vector2 gravityUp = new Vector2(0, 9.81f);
    public Vector2 gravityDown = new Vector2(0, -9.81f);
    public bool gravLeft;
    public bool gravRight;
    public bool gravUp;
    public bool gravDown;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;
        if (level == 1)
        {
            SetGravityDown();
        }
        else if (level == 2)
        {
            SetGravityRight();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGravityLeft()
    {
        Physics2D.gravity = gravityLeft * gravityMultiplier;
        gravLeft = true;
        gravRight = false;
        gravUp = false;
        gravDown = false;
    }
    public void SetGravityRight()
    {
        Physics2D.gravity = gravityRight * gravityMultiplier;
        gravLeft = false;
        gravRight = true;
        gravUp = false;
        gravDown = false;
    }
    public void SetGravityUp()
    {
        Physics2D.gravity = gravityUp * gravityMultiplier;
        gravLeft = false;
        gravRight = false;
        gravUp = true;
        gravDown = false;
    }
    public void SetGravityDown()
    {
        Physics2D.gravity = gravityDown * gravityMultiplier;
        gravLeft = false;
        gravRight = false;
        gravUp = false;
        gravDown = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
