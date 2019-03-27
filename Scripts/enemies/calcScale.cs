using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calcScale : MonoBehaviour
{
	 void Awake(){
			float xy = Random.Range(6,2);
		transform.localScale = new Vector3(xy, xy, 0);
		transform.position = new Vector3(transform.position.x, transform.position.y, 1);

	 }
}
