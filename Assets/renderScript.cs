using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderScript : MonoBehaviour {
    Renderer textRenderer;
	// Use this for initialization
	void Awake () {
        textRenderer = gameObject.GetComponent<Renderer>();
    }

    void Start()
    {
        textRenderer.sortingLayerID = 99;
    }
}
