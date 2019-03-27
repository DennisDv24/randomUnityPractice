using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombGeneratorController : MonoBehaviour
{
	public GameObject bombPrefab;
	public Transform playerPos; 

		public int instantiateTime;
			private int iterationInstantiateTime = 0;
		public float spawnRan = 15f;

	void Update(){
		if(iterationInstantiateTime == 0){
			Vector3 nextBombPosition = new Vector3(Random.Range(playerPos.position.x-spawnRan, playerPos.position.x+spawnRan),
											       Random.Range(playerPos.position.y-spawnRan/2, playerPos.position.y+spawnRan/2),0);

			GameObject bomb = Instantiate(bombPrefab, nextBombPosition, Quaternion.identity);
			bomb.transform.parent = gameObject.transform;	
				
				iterationInstantiateTime = instantiateTime;
		}

		else{
			iterationInstantiateTime--;
		}
	
	}


}
