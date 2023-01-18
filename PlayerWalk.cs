using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour {

	private float speed = 30f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;

	private bool isGrounded = false;
	private float jumpForce = 500f;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		PlayerWalkKeyboard ();
		Jump ();
	}

	private void PlayerWalkKeyboard() {
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			if (vel < maxVelocity) {
				forceX = speed;
			}

			Vector3 temp = transform.localScale;
			temp.x = 1f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);

		} else if (h < 0) {
			if (vel < maxVelocity) {
				forceX = -speed;
			}

			Vector3 temp = transform.localScale;
			temp.x = -1f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
		
		} else {
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2 (forceX, 0));

	}

	private void Jump() {
		if(Input.GetKey(KeyCode.Space)) {
			if (isGrounded) {
				isGrounded = false;
				myBody.AddForce (new Vector2 (0, jumpForce));
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Ground") {
			isGrounded = true;
		}
	}

} // class





































