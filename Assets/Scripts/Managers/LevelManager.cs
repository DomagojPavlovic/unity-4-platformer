using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Manager<LevelManager>
{
    public int currentLevel;

    [SerializeField]
    private GameObject levels;

    private GameObject currentEnemies;

    private Transform checkpoint;

    public void Start()
    {
        currentLevel = 1;
        LoadLevel();
    }

    public void LoadSelectLevel(int levelToLoad)
    {
        currentLevel = levelToLoad;
        LoadLevel();
    }

    public void LoadNextLevel()
    {
        ResetCheckpoint(checkpoint);
        checkpoint = null;
        ++currentLevel;
        LoadLevel();
    }

    public void LoadLevel()
    {
        int indexOfLevelToLoad = currentLevel - 1;
        if(levels.transform.childCount <= indexOfLevelToLoad)
        {
            EndGame();
            return;
        }

        UnloadAllLevels();

        GameObject levelToLoad = levels.transform.GetChild(indexOfLevelToLoad).gameObject;
        levelToLoad.SetActive(true);

        // duplicate the enemies gameobject and track it, so we can reset levels
        GameObject enemies = levelToLoad.transform.GetChild(2).gameObject;
        Destroy(currentEnemies);
        currentEnemies = Instantiate(enemies, levelToLoad.transform.position, Quaternion.identity);
        currentEnemies.SetActive(true);
        enemies.SetActive(false);

        if(!checkpoint)
        {
            PlayerManager.instance.MovePlayer(levelToLoad.transform.GetChild(0).GetChild(0));
            PlayerManager.instance.MoveCameraToPlayer();
        } else
        {
            PlayerManager.instance.MovePlayer(checkpoint);
        }
    }

    public void EndGame()
    {
        UIManager.instance.ShowNotification("You Win!", 10);
    }

    private void ResetCheckpoint(Transform checkpoint)
    {
        if (!checkpoint) return;
        checkpoint.GetComponent<Checkpoint>().ResetCheckpoint();
    }

    private void UnloadAllLevels()
    {
        for (int i = 0, max = levels.transform.childCount; i < max; ++i)
        {
            levels.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void PlayerReachedCheckpoint(Transform checkpoint)
    {
        ResetCheckpoint(this.checkpoint);
        this.checkpoint = checkpoint;
    }
}
