using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour {

	public float timeRemaining = 10f;
	public Canvas HUDCanvas;


    TextMesh text;                      // Reference to the Text component.


    void Awake ()
    {
        // Set up the reference.
        text = GetComponent <TextMesh> ();
    }

    void Start()
	{
		InvokeRepeating("decreaseTimeRemaining", 1f, 1f);
	}


    void Update()
	 {
	     if (timeRemaining == 0)
	     {
	         GameOver();
	         CancelInvoke();
	     }
	 
	     text.text = "Time left: " + timeRemaining + " seg.";
	 
	 }
	 
	 void decreaseTimeRemaining()
	 {
	     timeRemaining --;
	 }


    /*void decreaseTimeRemaining()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        counter -= 1;

		if ( counter < 0 )
		{
			GameOver();
			CancelInvoke();
		}
		else
        	text.text = "Time left: " + counter + " seg.";
    }*/

    void GameOver()
    {
    	HUDCanvas.enabled = true;
    	text.text = "Game Over!";
    }
}
