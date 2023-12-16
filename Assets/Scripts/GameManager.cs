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
    public bool levelComplete;
    AudioSource s;
    public AudioClip winJingle;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<AudioSource>();

        levelComplete = false;
        level = SceneManager.GetActiveScene().buildIndex;

        // Play music on the main menu screen
        if (level == 0)
        {
            s.Play();
        }
        else if (level == 11)
        {
            s.PlayOneShot(winJingle, 1.0f);
        }
        // Different gravity settings for each level
        else if (level == 1 || level == 3 || level == 6 || level == 7 || level == 9 || level == 10)
        {
            SetGravityDown();
        }
        else if (level == 2 || level == 8)
        {
            SetGravityRight();
        }
        else if (level == 4)
        {
            SetGravityLeft();
        }
        else if (level == 5)
        {
            SetGravityUp();
        }
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
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
