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
	private GameObject employee;

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
	}

	// Update is called once per frame
	void Update () {
		if(!inCoRoutine)
			StartCoroutine(RandomSoundness());

		if (Input.GetKeyDown ("x")) {
			inCoRoutine = true;
			randomSound = GameObject.Find ("Wok").GetComponent<AudioSource> ();
			randomSound.Play ();

			// Take a random number of employee and play the Wok
			GameObject[] employees = GameObject.FindGameObjectsWithTag ("employee");
			int randomNbEmployee = Random.Range (0, employees.Length);
			Debug.Log ("randomNbEmployee");
			Debug.Log (randomNbEmployee);
			for(int i = 0; i < randomNbEmployee;i++){
				float randomWokLaunch = Random.Range (0, 2);
				employee = employees[i];
				Debug.Log ("WokEmployeeSoundness");
				Debug.Log (randomWokLaunch);
				Invoke("WokEmployeeSoundness", randomWokLaunch);
			}
		}
	}

	public void WokEmployeeSoundness()
	{
		Debug.Log ("WokEmployeeSoundness call");
		RandomEmployeeSound randomEmployeeSound = employee.GetComponent<RandomEmployeeSound> ();
		randomEmployeeSound.WokSoundness ();
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
