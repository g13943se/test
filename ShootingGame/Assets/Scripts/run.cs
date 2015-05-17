using UnityEngine;
using System.Collections;

public class run : MonoBehaviour {
	public int speed = 10;
	
	void Start (){
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}
}
