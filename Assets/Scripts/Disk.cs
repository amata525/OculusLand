using UnityEngine;
using System.Collections;

public class Disk : MonoBehaviour {
	
	public bool operating = false;
	public float mSpeedAngle = 0.0f;  // 回転速度

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (operating) {
			if (this.name == "SpiningDisk0" || this.name == "SpiningDisk2") {
				this.transform.Rotate (new Vector3 (0, 0, mSpeedAngle) * Time.deltaTime);	
			} else {
				this.transform.Rotate (new Vector3 (0, 0, 0 - mSpeedAngle) * Time.deltaTime);	
			}
			
			
			if (Input.GetKey (KeyCode.W)) {
				if (mSpeedAngle < 720.0f) {
					mSpeedAngle += 1f;
				}
			} else if (Input.GetKey (KeyCode.S)) {
				if (mSpeedAngle >= 0.1f) {
					mSpeedAngle -= 1f;
				}
			}
		} else {
			mSpeedAngle = 0;
		}	
	}
}
