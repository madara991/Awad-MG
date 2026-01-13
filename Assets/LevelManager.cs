using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance;

    [Header("Read Only")]
	public int levelSelected;
    public CreaterLevelsSO levelData;


	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	public void SetLevelSelected(int level)
    {
        levelSelected = level;
        levelData = Resources.Load("Levels/level "+ levelSelected ) as CreaterLevelsSO;
    }

    // Called when player choice level in main menu
    public void SetlevelTarget(int level)
    {
        levelSelected = level;
    }

    public int GetLevelTarget()
    {
        return levelSelected;
    }

}
