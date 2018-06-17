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
	// Use this for initialization
	void Start () {
		if (activeScreens == null) {
			activeScreens = GameObject.FindGameObjectsWithTag ("active_screen");
			currentActiveScreen = activeScreens[0];
			shuffleAciveScreens();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!inCoRoutineEmployee)
			StartCoroutine(SpawnEmployee());

		if(!inCoRoutine && !currentActiveScreen.GetComponent<RandomActive>().enabled)
			StartCoroutine(ActiveScreenRandomly());
	}

	IEnumerator ActiveScreenRandomly(){
		inCoRoutine = true;
		// Take on object random
		int newRandomActiveScreenIdx = Random.Range (0, activeScreens.Length - 1);
		while (randomActiveScreenIdx == newRandomActiveScreenIdx) {
			newRandomActiveScreenIdx = Random.Range (0, activeScreens.Length - 1);
		}
		randomActiveScreenIdx = newRandomActiveScreenIdx;
		currentActiveScreen = activeScreens[randomActiveScreenIdx];
		randomActiveScript = currentActiveScreen.GetComponent<RandomActive>();
		//Debug.Log("randomActiveScript");
		//Debug.Log(randomActiveScript);
		randomActiveScript.enabled = true;
		randomActiveScript.activeScreen();
		int randomTime = Random.Range (0, 10);
		yield return new WaitForSeconds(randomTime);
		randomActiveScript.enabled = false;
		randomActiveScript.activeScreen();
		inCoRoutine = false;
	}

	IEnumerator SpawnEmployee(){
		inCoRoutineEmployee = true;
		int posX = Random.Range (-10, 10);
		int posZ = Random.Range (-10, 10);
		Vector3 position = new Vector3(posX,0,posZ);
		Quaternion rotation = new Quaternion(1,1,1,1);
		GameObject obj = Instantiate(employee, position, rotation) as GameObject;
		int randomTime = Random.Range (15, 30);
		yield return new WaitForSeconds(5);
		inCoRoutineEmployee = false;
	}

	void shuffleAciveScreens()
	{
		for (int i = 0; i < activeScreens.Length; i++) {
			GameObject tmp = activeScreens[i];
			int r = Random.Range (0, activeScreens.Length);
			activeScreens[i] = activeScreens[r];
			activeScreens[r] = tmp;
		}
		randomActiveScreenIdx = Random.Range (0, activeScreens.Length);
		currentActiveScreen = activeScreens[randomActiveScreenIdx];
	}

}
