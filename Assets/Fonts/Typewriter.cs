using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Typewriter : MonoBehaviour
// attach to UI Text component (with the full text already there)
{
	Text txt;
	string story;
    [SerializeField] private float charSpeed = 0.125f; 

	void Awake () 
	{
		txt = GetComponent<Text> ();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine ("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (charSpeed);
		}
	}

}
