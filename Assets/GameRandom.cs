using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRandom : MonoBehaviour {

	public GameObject employee;

	private GameObject[] activeScreens;
	private GameObject currentActiveScreen;	
	private RandomActive randomActiveScript;
	private int randomActiveScreenIdx;
	bool inCoRoutine;
	bool inCoRoutineEmployee;

	private GameObject configGO;
	private DoConfig config;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find ("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

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

	IEnumerator ActiveScreenRandomly(){
		inCoRoutine = true;
		// Take on object random
		randomActiveScreenIdx = Random.Range (1, activeScreens.Length - 1);
		currentActiveScreen = activeScreens[randomActiveScreenIdx];
		randomActiveScript = currentActiveScreen.GetComponent<RandomActive>();
		randomActiveScript.enabled = true;
		randomActiveScript.activeScreen();
		int randomTime = Random.Range (config.activeScreenRangeMin, config.activeScreenRangeMax);
		yield return new WaitForSeconds(randomTime);
		randomActiveScript.enabled = false;
		randomActiveScript.activeScreen();
		inCoRoutine = false;
	}

	IEnumerator SpawnEmployee(){
		inCoRoutineEmployee = true;
		float posX = Random.Range (config.spawnEmployeePosXRangeMin, config.spawnEmployeePosXRangeMax);
		float posZ = Random.Range (config.spawnEmployeePosZRangeMin, config.spawnEmployeePosZRangeMin);
		Vector3 position = new Vector3(posX,0,posZ);
		Quaternion rotation = new Quaternion(1,1,1,1);
		GameObject obj = Instantiate(employee, position, rotation) as GameObject;
		int randomTime = Random.Range (config.spawnEmployeeRangeMin, config.spawnEmployeeRangeMax);
		yield return new WaitForSeconds(config.spawnEmployeeTimeBetween);
		inCoRoutineEmployee = false;
	}

}
