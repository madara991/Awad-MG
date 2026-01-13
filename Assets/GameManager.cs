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

		totalCards = GetAllItems().Length;
		totalMatches = totalCards / 2;

		Instantiate(LevelManager.Instance.levelData.ContentSize, GridAreaContiner);
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

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	Item[] GetAllItems()
	{
		return FindObjectsByType<Item>(FindObjectsSortMode.None);
	}
}
