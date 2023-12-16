using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject levelSelectScreen;
    // Start is called before the first frame update
    void Start()
    {
        LoadTitle();
    }

    public void LoadLevelSelect()
    {
        titleScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }
    public void LoadTitle()
    {
        titleScreen.SetActive(true);
        levelSelectScreen.SetActive(false);
    }
}
