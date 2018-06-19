﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayerSound : MonoBehaviour {
	
	private AudioSource randomSound;
	private AudioSource[] audioSources;

	// Config variables
	private GameObject configGO;
	private DoConfig config;

	private bool inCoRoutine;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

		// Init random player sound
		audioSources = config.playerRandomAudioSources;
	}

	// Update is called once per frame
	void Update () {
		if(!inCoRoutine)
			StartCoroutine(RandomSoundness());
	}

	IEnumerator RandomSoundness()
	{
		inCoRoutine = true;
		randomSound = audioSources[Random.Range(0, audioSources.Length - 1)];
		randomSound.Play();

		// Wait until the next to employee to spawn
		int nextSoundTime = Random.Range (config.playerRandomAudioSourceRangeMin, config.playerRandomAudioSourceRangeMax);
		yield return new WaitForSeconds(nextSoundTime);

		inCoRoutine = false;
	}
}