using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour
{


public int timeToExploit = 100;
	private int timeToExploitIterator;

	private Animator anim;


	void Start(){
		timeToExploitIterator = timeToExploit;
		anim = GetComponent<Animator>();
	}
			private bool canExploit = false;
		void Update(){
			anim.SetBool("Exploit", canExploit);
		}

	void FixedUpdate(){
		if(timeToExploitIterator == 0){
			exploit();
		}
		else{
			timeToExploitIterator--;
		}
	
	}

	public float exploitAnimationTime_inSeconds = 1;
		void exploit(){
			transform.gameObject.tag = "Lethal";
			canExploit = true;
			Destroy(gameObject, exploitAnimationTime_inSeconds);
		
		}


}
