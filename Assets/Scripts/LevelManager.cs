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

}