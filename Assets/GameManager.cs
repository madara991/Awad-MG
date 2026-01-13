using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[Header("Game Stats")]
	public int turnNumber;
	public int matchNumber;       

	[Header("Win Events")]
	public UnityEvent OnGameWin;

	public Transform GridAreaContiner; // the gameobject that hold size grid of items/images

	private int totalCards;
	private int totalMatches;

	private bool isGameFinished;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	void Start()
	{
		ResetGame();

		InitliazLevel();

		totalCards = GetAllItems().Length;
		totalMatches = totalCards / 2;
	}

	//Initlailize level (grid images)
	void InitliazLevel()
	{
		var contentSizePrefabTaken = LevelManager.Instance.levelData.ContentSizePrefab;
		Instantiate(contentSizePrefabTaken, GridAreaContiner);

		Item[] items = GetAllItems();

		Sprite[] sourceSprites = LevelManager.Instance.levelData.sprites;

		List<Sprite> spritePairs = new List<Sprite>();

		foreach (var sprite in sourceSprites)
		{
			spritePairs.Add(sprite);
			spritePairs.Add(sprite); 
		}

		if (spritePairs.Count != items.Length)
		{
			Debug.LogError("Items count does not match sprite pairs count!");
			return;
		}

		Shuffle(spritePairs);

		// 7. Assign sprites to items
		for (int i = 0; i < items.Length; i++)
		{
			items[i].image.sprite = spritePairs[i];
		}
	}

	void Shuffle<T>(List<T> list)
	{
		for (int i = list.Count - 1; i > 0; i--)
		{
			int rnd = Random.Range(0, i + 1);
			(list[i], list[rnd]) = (list[rnd], list[i]);
		}
	}

	public void RegisterTurn()
	{
		if (isGameFinished) return;
		turnNumber++;
	}

	public void RegisterMatch()
	{
		if (isGameFinished) return;

		matchNumber++;

		if (matchNumber >= totalMatches)
		{
			WinGame();
		}
	}

	void WinGame()
	{
		if (isGameFinished) return;

		isGameFinished = true;

		Debug.Log("YOU WIN!");

		OnGameWin?.Invoke();
	}

	public void ResetGame()
	{
		turnNumber = 0;
		matchNumber = 0;
		isGameFinished = false;
	}

	Item[] GetAllItems()
	{
		return FindObjectsByType<Item>(FindObjectsSortMode.None);
	}
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
