using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEmployeeSound : MonoBehaviour {

	private AudioSource employeeSound;
	private AudioSource randomSound;
	private AudioSource[] employeeBackgroundSounds;

	// Config variables
	private GameObject configGO;
	private DoConfig config;

	private bool inCoRoutine;
	private bool justSpwan;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

		// Init random employee sound
		employeeBackgroundSounds = config.employeeBackgroundRandomAudioSources;

		// No sound, no cookie :p
		if (employeeBackgroundSounds.Length == 0) {
			inCoRoutine = true;
		}

		employeeSound = GetComponent<AudioSource>();

		justSpwan = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!inCoRoutine)
			StartCoroutine(RandomBackgroundSoundness());
	}

	// Update is called once per frame
	public void RandomSoundness (AudioSource randomSound) {
		employeeSound.clip = randomSound.clip;
		employeeSound.Play();
	}

	IEnumerator RandomBackgroundSoundness()
	{
		inCoRoutine = true;

		if (!justSpwan) {
			randomSound = employeeBackgroundSounds [Random.Range (0, employeeBackgroundSounds.Length - 1)];
			randomSound.Play ();
		} else {
			justSpwan = false;
		}

		// Wait until the next to employee to spawn
		int nextSoundTime = Random.Range (config.employeeBackgroundRandomAudioSourceRangeMin, config.employeeBackgroundRandomAudioSourceRangeMax);
		Debug.Log (nextSoundTime);
		yield return new WaitForSeconds(nextSoundTime);

		inCoRoutine = false;
	}

	public void WokSoundness()
	{
		employeeSound.clip = GameObject.Find ("Wok").GetComponent<AudioSource> ().clip;
		employeeSound.Play ();
	}
}
