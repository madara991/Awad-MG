using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	public AudioSource correctSound;
	public AudioSource WrongSound;
	public AudioSource WinSound;
	public AudioSource LoseSound;


	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	public void PlayMatchSound()
	{
		correctSound.Play();
	}

	public void PlayFailSound()
	{
		WrongSound.Play();

	}

	public void PlayWinSound()
	{
		WinSound.Play();
	}

	public void PlayLoseSound()
	{
		LoseSound.Play();

	}
}
