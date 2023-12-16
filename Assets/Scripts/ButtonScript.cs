using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public int level;
    private Button button;
    private GameManager m;

    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLevel()
    {
        m.LoadLevel(level);
    }
}
