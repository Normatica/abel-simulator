using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEmployeeName : MonoBehaviour {

	// Config variables
	private GameObject configGO;
	private DoConfig config;
	private TextMesh name;

	// Use this for initialization
	void Start () {
		// Init Config
		configGO = GameObject.Find("Config").gameObject;
		config = configGO.GetComponent<DoConfig>();

		string randomEmployeeName = config.employeeRandomNames [Random.Range (0, config.employeeRandomNames.Length)];
		name = GameObject.Find("Name").gameObject.GetComponent<TextMesh>();
		name.text = randomEmployeeName;			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
