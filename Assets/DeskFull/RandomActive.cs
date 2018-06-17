using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class RandomActive : MonoBehaviour {

	public bool enabled;
	private AudioSource screenSound;
	// Use this for initialization
	void Start () {
		// Hide by default
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer> ();
		AudioSource screenSound = GetComponent<AudioSource>();
		mr.enabled = enabled = false; 
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void activeScreen()
	{
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer> ();
		mr.enabled = enabled;
		if (enabled) {
			screenSound = GetComponent<AudioSource>();
			screenSound.Play();
		}
	}

	public void onClickScreen()
	{
		ScoreManager.score += 1;
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer> ();
		enabled = false;
		mr.enabled = enabled;
	}
}
