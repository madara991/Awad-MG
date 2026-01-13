using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[Header("Game Stats")]
	public int turnNumber;
	public int matchNumber;

	private int totalCards;         
	private int totalMatches;        

	[Header("Win Events")]
	public UnityEvent OnGameWin;

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
		totalMatches = totalCards / 2;

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
}
