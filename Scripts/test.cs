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
	public bool attack = false;
		private float attackMaxIterationTime = 10; //attack animation time
		private float attackIterationTime = 0;
	
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
		anim.SetBool("attack", attack);

			if(playerAlive == false){
				reloadScene();
			}
			if(Input.GetMouseButtonDown(0)){
				attack = true;
				attackIterationTime = attackMaxIterationTime;
			}
				idle = true;
				movX = false;
				movY = false;
	}
	void FixedUpdate(){
		move();
		calcAttackTime();
	}


		void move(){
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

			void calcAttackTime(){
				if(attack){
					if(attackIterationTime == 0){
						attack = false;
					}
					else{
						attackIterationTime--;
					}
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