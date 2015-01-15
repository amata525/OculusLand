using UnityEngine;
using System.Collections;

public class Disk : MonoBehaviour {
	
	public bool operating = false;
	public float mSpeedAngle = 0.0f;  // 回転速度
	public float time_count = 0.0f;

	// Use this for initialization
	void Start () {
		operating = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (operating) {
			if (this.transform.parent.name == "SpiningDisk0" || this.transform.parent.name == "SpiningDisk2") {
				this.transform.Rotate (new Vector3 (0, 0, mSpeedAngle) * Time.deltaTime);	
			} else {
				this.transform.Rotate (new Vector3 (0, 0, 0f-mSpeedAngle) * Time.deltaTime);	
			}
			
			if(time_count > 60.0f){
				mSpeedAngle -= 3f;
				if (mSpeedAngle < 0.0f) {
					mSpeedAngle = 0f;
				}
			}
			else{
				if (mSpeedAngle < 360.0f) {
					mSpeedAngle += 1f;
				}
				else{
					time_count += Time.deltaTime;
				}
			}
		} else {
			mSpeedAngle = 0;
			time_count = 0;
		}	
	}
}
