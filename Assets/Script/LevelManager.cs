using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance;

    [Header("Read Only")]
	public int levelSelected;
    public LevelData levelData;

    // this script for managment levels for started 
	void Awake()
	{
		if (Instance == null)
        {
			Instance = this;
            DontDestroyOnLoad(gameObject);
        }
		else
			Destroy(gameObject);
	}
    
	public void SetLevelSelected(int level)
    {
        levelSelected = level;
        Debug.Log("level" + levelSelected);
        levelData = Resources.Load("Levels/level "+ levelSelected ) as LevelData;
    }

    // Called when player choice level in main menu
    public void SetlevelTarget(int level)
    {
        levelSelected = level;
    }

    public int GetLevelSelected()
    {
        return levelSelected;
    }

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
