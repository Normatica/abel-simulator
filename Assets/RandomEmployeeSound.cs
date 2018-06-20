using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEmployeeSound : MonoBehaviour {

	private AudioSource employeeSound;
	// Use this for initialization
	void Start () {
		employeeSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Update is called once per frame
	public void RandomSoundness (AudioSource randomSound) {
		employeeSound = randomSound;
		employeeSound.Play();
	}
}
