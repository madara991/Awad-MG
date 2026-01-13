using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsGame : MonoBehaviour
{
    public Text turnText;
    public Text matchText;

    private MatchingSystem matchingSystem;

    private int currentTurnNumber;
    private int currentMatchNumber;

    private void Awake()
    {
        matchingSystem = FindObjectOfType<MatchingSystem>();
    }

    private void OnEnable()
    {
        matchingSystem.OnSuccessMatching.AddListener(IncrementTurn);
        matchingSystem.OnFailMatching.AddListener(IncrementTurn);

		matchingSystem.OnSuccessMatching.AddListener(IncerementMatch);
	}

    private void OnDisable()
    {
		matchingSystem.OnSuccessMatching.RemoveListener(IncrementTurn);
		matchingSystem.OnFailMatching.RemoveListener(IncrementTurn);

		matchingSystem.OnSuccessMatching.RemoveListener(IncerementMatch);
	}
    public void IncrementTurn()
    {
        currentTurnNumber++;
        turnText.text = "Turn: " + currentTurnNumber.ToString();

	}

    public void IncerementMatch()
    {
        currentMatchNumber++;
		matchText.text = "Match: " + currentMatchNumber.ToString();
	} 
}
