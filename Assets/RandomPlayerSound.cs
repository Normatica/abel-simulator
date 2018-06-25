using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayerSound : MonoBehaviour {
	
	private AudioSource randomSound;
	private AudioSource[] audioSources;

	// Config variables
	private GameObject configGO;
	private DoConfig config;

	private bool inCoRoutine;
	private bool inCoRoutineWok;
	private GameObject[] employees;
	private GameObject employee;
	private int randomNbEmployee;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

		// Init random player sound
		audioSources = config.playerRandomAudioSources;

		// No sound, no cookie :p
		if (audioSources.Length == 0) {
			inCoRoutine = true;
		}
		inCoRoutineWok = true;
	}

	// Update is called once per frame
	void Update () {
		if(!inCoRoutine)
			StartCoroutine(RandomSoundness());

		if (Input.GetKeyDown ("x")) {
			inCoRoutineWok = false;
			randomSound = GameObject.Find ("Wok").GetComponent<AudioSource> ();
			randomSound.Play ();

			// Take a random number of employee and play the Wok
			employees = GameObject.FindGameObjectsWithTag ("employee");
			randomNbEmployee = Random.Range (0, employees.Length);
		}

		if(!inCoRoutineWok && randomNbEmployee > 0)
			StartCoroutine(WokEmployeeSoundness());
	}

	IEnumerator WokEmployeeSoundness()
	{
		inCoRoutineWok = true;
		int randomIndxEmployee = Random.Range (0, employees.Length);
		employee = employees[randomIndxEmployee];		
		RandomEmployeeSound randomEmployeeSound = employee.GetComponent<RandomEmployeeSound> ();
		randomEmployeeSound.WokSoundness ();
		float nextSoundTime = Random.Range (config.employeeWokAudioSourceRangeMin, config.employeeWokAudioSourceRangeMax);
		yield return new WaitForSeconds(nextSoundTime);
		inCoRoutineWok = false;
		randomNbEmployee--;
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
