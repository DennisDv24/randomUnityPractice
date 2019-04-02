using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeController : MonoBehaviour
{
public float shakeFactor;
public float shakeVel;

	public string transitionToShake;
		Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		if(anim.GetCurrentAnimatorStateInfo(0).IsName(transitionToShake)){
			doShake();
		}
	}

		void doShake(){
	
		}

}
