using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Spaceship spaceship;

	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		while (true) {
			spaceship.Shot(transform);
			yield return new WaitForSeconds(spaceship.shotDelay);
		}
	}

	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;

		// Rigidbody2D.velocity = speed * direction;
		// 上記の表記じゃダメらしい(Unity5は) GetComponentを使う
		// GetComponent<Rigidbody2D> ().velocity = direction * speed;
		spaceship.Move (direction);
	}

	void OnTriggerEnter2D(Collider2D c){ // 引数はぶつかってきた相手のCollider
		Destroy (c.gameObject);
		spaceship.Explosion ();
		Destroy (gameObject);
	}
}
