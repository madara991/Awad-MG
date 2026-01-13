using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour , IPointerClickHandler
{
    public Image image;
    public GameObject itemTarget;
	public GameObject luckGO;

	public bool isPressed;
    public bool isMatched;



    private MatchingSystem matchingSystem;
    private Action OnFlip;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click!");

        matchingSystem.OpenCard(this);

	}


    // Start is called before the first frame update
    void Start()
    {
		matchingSystem = FindObjectOfType<MatchingSystem>();

	}

   
    public void Flip()
    {
        luckGO.SetActive(false);
		OnFlip?.Invoke();

	}

	public void ReturnFlip()
    {
        luckGO.SetActive(true);
    }

    public void Matched()
    {
        luckGO.SetActive(false);
        itemTarget.SetActive(false);
    }
}
