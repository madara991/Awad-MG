using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchingSystem : MonoBehaviour
{
    private Item[] items;

    [SerializeField] private Item previousItem;
    [SerializeField] private Item nextItem;

    private Coroutine matchingCoroutine;


	public float successMatchDeley = 0.5f;
	public float failMatchDeley = 0.5f;


	public UnityEvent OnSuccessMatching;
	public UnityEvent OnFailMatching;

	void Start()
    {
        items = GetComponentsInChildren<Item>();
    }


    public void OpenCard(Item item)
    {
        if(previousItem == null)
        {
            previousItem = item;
            item.Flip();
        }
        else
        if(nextItem == null)
        {
            nextItem = item;
            item.Flip();

			matchingCoroutine = StartCoroutine(Matching(previousItem, nextItem));

            return;
		}

	}

     IEnumerator Matching(Item item1 , Item item2)
     {
        if (item1.image.sprite != item2.image.sprite)
        {
			StartCoroutine(ReturnFlipCards());
			Debug.Log("is not match");
            yield return null;
		}

		item1.isMatched = true;
        item2.isMatched = true;

        yield return new WaitForSeconds(successMatchDeley);

        item1.Matched();
		item2.Matched();

		previousItem = null;
		nextItem = null;

		OnSuccessMatching?.Invoke();
	 }

	IEnumerator ReturnFlipCards()
	{
		if (previousItem == null && nextItem == null)
			yield return null;

		yield return new WaitForSeconds(failMatchDeley);

		previousItem.ReturnFlip();
		nextItem.ReturnFlip();
		previousItem = null;
		nextItem = null;
	}

	// win when finish all cards match
	// add sound effect 
	// try order code 
	// calculate turning number 
	// caluclate match number (( inltlize number match from number cards when START)
}
