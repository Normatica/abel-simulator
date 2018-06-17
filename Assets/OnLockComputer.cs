using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLockComputer : MonoBehaviour {
	private AudioSource helenaAaah;
	// Use this for initialization
	void Start () {
		AudioSource helenaAaah = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void onLockScreen()
	{
		helenaAaah = GetComponent<AudioSource>();
		helenaAaah.Play();
	}
}
