using UnityEngine;
using System.Collections;

public class SkeletonWalk : MonoBehaviour {

	private float speed = 3f;
	public bool walkLeft;

	void Start () {
		StartCoroutine (ChangeDirection());
	}

	void Update () {
		Walk ();
	}

	private void Walk() {
		Vector3 temp = transform.position;
		Vector3 tempScale = transform.localScale;
		if (walkLeft) {
			temp.x -= speed * Time.deltaTime;
			tempScale.x = -Mathf.Abs (tempScale.x);
		} else {
			temp.x += speed * Time.deltaTime;
			tempScale.x = Mathf.Abs (tempScale.x);
		}
		transform.position = temp;
		transform.localScale = tempScale;
	}

	IEnumerator ChangeDirection() {
		yield return new WaitForSeconds (3f);
		walkLeft = !walkLeft;
		StartCoroutine (ChangeDirection());
	}

} // class








































