using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{

public const float maxVel = 0.1f;
private Rigidbody2D rb2d;
private Animator anim;
	public bool playerAlive = true;
	
	void Start(){
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	 
	private bool movX = false;
	private bool movY = false;
	private bool idle = true;

	void Update(){
			anim.SetBool("MovX", movX);
			anim.SetBool("MovY", movY);
			anim.SetBool("idle", idle);
			anim.SetBool("alive", playerAlive);

		if(playerAlive == false){
			reloadScene();
		}
	}
	void FixedUpdate(){
		move();
	}


		void move(){
				idle = true;
				movX = false;
				movY = false;
			
			if(Input.GetKey(KeyCode.W)){
			rb2d.position += new Vector2(0,maxVel);
				movY = true;
				idle = false;
			}
			if(Input.GetKey(KeyCode.S)){
			rb2d.position += new Vector2(0,-maxVel);
				movY = true;
				idle = false;
			}	
			if(Input.GetKey(KeyCode.D)){
			rb2d.position += new Vector2(maxVel,0);
				movX = true;
				idle = false;
			}
			if(Input.GetKey(KeyCode.A)){
			rb2d.position += new Vector2(-maxVel,0);
				movX = true;
				idle = false;
			}
		}

			void calcAlive(){
				if(playerAlive != true){
					SceneManager.LoadScene("SampleScene");
				}
			}

			private bool reload = false;
				private int reloadTime = 20;

			void OnTriggerStay2D(Collider2D col){
				if(col.gameObject.tag == "Lethal"){
					playerAlive = false;
					reload = true;
				}
			}

			void OnCollisionStay2D(Collision2D col){

				if(col.gameObject.tag == "Lethal"){
					playerAlive = false;
					reload = true;
				}
			}

					void reloadScene(){
						if(reloadTime == 0){
							SceneManager.LoadScene("SampleScene");
						}
						else{
							reloadTime--;
						}
					}

	
}