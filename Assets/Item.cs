using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
	public Image image;
	public GameObject itemTarget;
	public GameObject luckGO;

	public bool isMatched { get; set; }
	public bool IsFlipped { get; private set; }

	private MatchingSystem matchingSystem;

	void Start()
	{
		matchingSystem = FindObjectOfType<MatchingSystem>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (isMatched || IsFlipped)
			return;

		matchingSystem.OpenCard(this);
	}

	public void Flip()
	{
		IsFlipped = true;
		luckGO.SetActive(false);
	}

	public void ReturnFlip()
	{
		IsFlipped = false;
		luckGO.SetActive(true);
	}

	public void Matched()
	{
		isMatched = true;
		IsFlipped = true;
		luckGO.SetActive(false);
		itemTarget.SetActive(false);
	}
}
