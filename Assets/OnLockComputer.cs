using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLockComputer : MonoBehaviour {
	
	// All employee on the game
	private GameObject[] employees;

	private AudioSource[] audioSources;
	private RandomEmployeeSound randomEmployeeSoundScript;

	// Config variables
	private GameObject configGO;
	private DoConfig config;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find ("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

		// Init random player sound
		audioSources = config.employeeRandomAudioSources;

		// Retrieve screens
		if (employees == null) {
			employees = GameObject.FindGameObjectsWithTag ("employee");
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void onLockScreen()
	{
		// No sound, no cookie :p
		if (audioSources.Length != 0) {
			GameObject employeeRandom = employees [Random.Range (0, employees.Length - 1)];
			randomEmployeeSoundScript = employeeRandom.GetComponent<RandomEmployeeSound> ();
			AudioSource employeeRandomAudioSource = audioSources [Random.Range (1, audioSources.Length - 1)];
			randomEmployeeSoundScript.RandomSoundness (employeeRandomAudioSource);
		}
	}
}
