using UnityEngine;
using System.Collections;

public class LevelManager
{
    private static LevelManager levelManager;
    public GameObject currentCheckpoint { get; set; }

    public static LevelManager Instance()
    {
        if (levelManager == null)
            levelManager = new LevelManager();
        return levelManager;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}