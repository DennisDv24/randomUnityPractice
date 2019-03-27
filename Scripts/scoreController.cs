using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{

	private float score = 0;
	public Text scoreToText;

	void Update(){
		score+=7;
		scoreToText.text = score.ToString();
	
	}


}
