using UnityEngine;
using System.Collections;

public class AroundRotation : MonoBehaviour {

	GameObject[] cups = new GameObject[4];

	float mSpeedAngle = 0.0f; // 回転速度 ( degree/s )

	public bool operating = false;   // コーヒーカップマシンが動いているかどうか

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			cups[i] = GameObject.Find ("Cup" + i);
		}	
	}
	
	// Update is called once per frame
	void Update () {

		if (operating) {
			if (mSpeedAngle < 100.0f) {
				mSpeedAngle += 0.1f;
			}

			for (int i = 0; i < 4; i++) {
				cups [i].transform.RotateAround (this.transform.position, Vector3.up, mSpeedAngle * Time.deltaTime);
			}

		} else {
			mSpeedAngle = 0;
		}
	}
}
