using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchingSystem : MonoBehaviour
{
	private Item previousItem;
	private Item nextItem;

	private Coroutine matchingCoroutine;
	private bool isCheckingMatch;
	private bool currentMatchIsSuccess;

	private Animator animator;

	public float successMatchDeley = 0.4f;
	public float failMatchDeley = 0.4f;

	public UnityEvent OnSuccessMatching;
	public UnityEvent OnFailMatching;

	public void OpenCard(Item item)
	{
		if (isCheckingMatch)
		{
			HandleFastInput();
		}

		if (previousItem == null)
		{
			previousItem = item;
			item.Flip();
			return;
		}

		if (nextItem == null)
		{
			nextItem = item;
			item.Flip();

			currentMatchIsSuccess = previousItem.image.sprite == nextItem.image.sprite;

			matchingCoroutine = StartCoroutine(Matching(previousItem, nextItem));

			GameManager.Instance.RegisterTurn();
		}
	}

	IEnumerator Matching(Item item1, Item item2)
	{
		isCheckingMatch = true;

		if (!currentMatchIsSuccess)
		{
			yield return new WaitForSeconds(failMatchDeley);
			item1.ReturnFlip();
			item2.ReturnFlip();

			ResetItems();
			OnFailMatching?.Invoke();
			yield break;
		}

		item1.PlayMinimizeAnim();
		item2.PlayMinimizeAnim();
		yield return new WaitForSeconds(successMatchDeley);
		CompleteMatch(item1, item2);
	}

	// this function that override open other cards while matching
	// make playing and open cards more fast and smoothly
	void HandleFastInput()
	{
		if (matchingCoroutine != null)
		{
			StopCoroutine(matchingCoroutine);
			matchingCoroutine = null;
		}

		if (currentMatchIsSuccess && previousItem != null && nextItem != null)
		{
			CompleteMatch(previousItem, nextItem);
		}
		else
		{
			if (previousItem != null)
				previousItem.ReturnFlip();

			if (nextItem != null)
				nextItem.ReturnFlip();

			ResetItems();
		}
	}

	void CompleteMatch(Item item1, Item item2)
	{
		item1.Matched();
		item2.Matched();

		ResetItems();
		OnSuccessMatching?.Invoke();


		GameManager.Instance.RegisterMatch();
	}

	

	void ResetItems()
	{
		previousItem = null;
		nextItem = null;
		isCheckingMatch = false;
		currentMatchIsSuccess = false;
	}
}
