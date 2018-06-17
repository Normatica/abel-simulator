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
		Debug.Log("ActiveScreenRandomly");
		Debug.Log(inCoRoutine);
		inCoRoutine = true;
		Debug.Log(inCoRoutine);
		// Take on object random
		int newRandomActiveScreenIdx = Random.Range (0, activeScreens.Length);
		while (randomActiveScreenIdx == newRandomActiveScreenIdx) {
			newRandomActiveScreenIdx = Random.Range (0, activeScreens.Length);
		}
		randomActiveScreenIdx = newRandomActiveScreenIdx;
		Debug.Log("currentActiveScreen choose: ");
		Debug.Log(randomActiveScreenIdx);
		currentActiveScreen = activeScreens[randomActiveScreenIdx];
		Debug.Log("activeScreen call ");
		randomActiveScript = currentActiveScreen.GetComponent<RandomActive>();
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
		Debug.Log("currentActiveScreen choose: ");
		Debug.Log(randomActiveScreenIdx);

	}

}
