using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyController : MonoBehaviour
{
	
private Rigidbody2D rb2d;

	private enemyGeneratorController generator;
		private Transform playerPos;
		private Animator anim;
			private int destroyIteration;

	void Awake() {
		transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
	}
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
			anim = GetComponent<Animator>();
			generator = GetComponentInParent<enemyGeneratorController>();
			playerPos = generator.playerPos;
			destroyIteration = generator.destroyTime * 60;
    }


		public float enemyVelFactor = 4f;

	public float rotateSpeed = 300f;
    void FixedUpdate()
    {
		rotation();
		calcPosition();
		calcDestroy();
	}

		void rotation(){
			Vector2 dir = (Vector2)playerPos.position - rb2d.position;
			dir.Normalize();
			float toRotate = Vector3.Cross(dir, transform.up).z;
			rb2d.angularVelocity = -toRotate * rotateSpeed;
		}
		void calcPosition(){
			rb2d.velocity = transform.up * enemyVelFactor;
				//transform.position = Vector2.MoveTowards(transform.position, playerPos.position, finalVel);
			/*
			if(Vector2.Distance(transform.position, playerPos.position) < distToStop){
				transform.position += new Vector3(finalVel/1.4f, -finalVel/1.4f, 0);
			}*/
		}

		void calcDestroy(){
			destroyIteration--;
				if(destroyIteration == 60){
					anim.SetBool("alive",false);
				}
		}
		
}
