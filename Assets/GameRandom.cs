using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRandom : MonoBehaviour {

	// Employee gameobject to use for spawn random
	public GameObject employee;

	// All screens on the game
	private GameObject[] activeScreens;

	// Current random screen activated
	private GameObject currentActiveScreen;	
	private RandomActive randomActiveScript;
	private int randomActiveScreenIdx;

	// Coroutines
	bool inCoRoutine;
	bool inCoRoutineEmployee;

	// Config variables
	private GameObject configGO;
	private DoConfig config;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find ("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

		// Retrieve screens
		if (activeScreens == null) {
			activeScreens = GameObject.FindGameObjectsWithTag ("active_screen");
			currentActiveScreen = activeScreens[1];
			randomActiveScript = currentActiveScreen.GetComponent<RandomActive>();
		}
	}
	
	// Update is called once per frame
	void Update () {		
		if(!inCoRoutineEmployee)
			StartCoroutine(SpawnEmployee());

		if(!inCoRoutine)
			StartCoroutine(ActiveScreenRandomly());
	}

	// Coroutine to active random screen
	IEnumerator ActiveScreenRandomly(){
		inCoRoutine = true;

        // Take a random screen
        randomActiveScreenIdx = Random.Range (0, activeScreens.Length - 1);
		currentActiveScreen = activeScreens[randomActiveScreenIdx];
		randomActiveScript = currentActiveScreen.GetComponent<RandomActive>();

		// Call screen coroutine enable/disabled
		int randomTime = Random.Range (config.activeScreenRangeMin, config.activeScreenRangeMax);
		yield return StartCoroutine(randomActiveScript.screenAction(randomTime));
		inCoRoutine = false;
	}

	// Coroutine to spawm employee
	IEnumerator SpawnEmployee(){
		inCoRoutineEmployee = true;

		// Calcul random position
		float posX = Random.Range (config.spawnEmployeePosXRangeMin, config.spawnEmployeePosXRangeMax);
		float posZ = Random.Range (config.spawnEmployeePosZRangeMin, config.spawnEmployeePosZRangeMin);
		Vector3 position = new Vector3(posX,0,posZ);
		Quaternion rotation = new Quaternion(1,1,1,1);

		// Create new employee
		GameObject obj = Instantiate(employee, position, rotation) as GameObject;

		// Wait until the next to employee to spawn
		int randomTime = Random.Range (config.spawnEmployeeRangeMin, config.spawnEmployeeRangeMax);
		yield return new WaitForSeconds(config.spawnEmployeeTimeBetween);
		inCoRoutineEmployee = false;
	}
}
