using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGeneratorController : MonoBehaviour
{
    
	public GameObject enemyPrefab;
	public Transform playerPos; 

	public int instantiateTime;
	public int destroyTime;
		private int iteratorInstantiateTime = 0;


	void Update(){

		if(iteratorInstantiateTime == 0){
			Vector3 nextEnemyPos;
				do{
					nextEnemyPos = new Vector3(Random.Range(playerPos.position.x-10, playerPos.position.x+10),
											   Random.Range(playerPos.position.y-5, playerPos.position.y+5),0);

				} while(Vector3.Distance(playerPos.position, nextEnemyPos) <5);


			GameObject enemy = Instantiate(enemyPrefab, nextEnemyPos, Quaternion.identity);
			enemy.transform.parent = gameObject.transform;
				Destroy(enemy,destroyTime);	
				iteratorInstantiateTime = instantiateTime;

		}
		else{
			iteratorInstantiateTime--;		
		}

	}




}
