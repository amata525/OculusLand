using UnityEngine;
using System.Collections;

public class Buranko : MonoBehaviour {

	public bool operating = false;
	public float mForce;  // 回転力
	public float time_count = 0.0f;

	float xPosOld;

	// Use this for initialization
	void Start () {
		xPosOld = 0;
		mForce = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (operating) {

			float xPos = transform.position.x;
			float yPos = transform.position.y;

			if (xPosOld < xPos) {
				rigidbody.AddForce (new Vector3 (mForce, 0, 0));
			} else {
				rigidbody.AddForce (new Vector3 (-mForce, 0, 0));
			}
			xPosOld = xPos;

			if(time_count > 60.0f){
				mForce -= 2.0f;
				if (mForce < -1.0f) {
					mForce = -1f;
				}
			}
			else{
				if (mForce < 11.0f) {
					if(yPos <= 0.9f){
						mForce += 0.5f;
					}
				}
				else{
					time_count += Time.deltaTime;
				}
			}

		} else {
			mForce = 0;
			time_count = 0;
		}
	}
}
