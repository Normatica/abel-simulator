using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class use to be abel to configure the game easier
public class DoConfig : MonoBehaviour {

	public int activeScreenRangeMin = 0;
	public int activeScreenRangeMax = 10;

	public float spawnEmployeePosXRangeMin = -10;
	public float spawnEmployeePosXRangeMax = 10;

	public float spawnEmployeePosZRangeMin = -10;
	public float spawnEmployeePosZRangeMax = 10;

	public int spawnEmployeeTimeBetween = 5;
	public int spawnEmployeeRangeMin = 15;
	public int spawnEmployeeRangeMax = 30;

	public AudioSource[] employeeRandomAudioSources;
	public AudioSource[] employeeBackgroundRandomAudioSources;
	public int employeeBackgroundRandomAudioSourceRangeMin = 15;
	public int employeeBackgroundRandomAudioSourceRangeMax = 20;
	public float employeeWokAudioSourceRangeMin = 0.5f;
	public float employeeWokAudioSourceRangeMax = 2.5f;
	public string[] employeeRandomNames;

	public AudioSource[] playerRandomAudioSources;
	public int playerRandomAudioSourceRangeMin = 0;
	public int playerRandomAudioSourceRangeMax = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
