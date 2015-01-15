using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	GameObject playerObj;
	//GameObject playerCamera;

	GameObject redCup;
	GameObject blueCup;

	GameObject[] cups = new GameObject[4];
	GameObject coffeeCupObj;

	Cup[] cupScripts = new Cup[4];
	AroundRotation coffeeCupScript;

	GameObject redDisk;
	GameObject blueDisk;

	GameObject[] disks = new GameObject[4];
	Disk[] diskScripts = new Disk[4];

	GameObject buranko;
	Buranko burankoScript;

	// Use this for initialization
	void Start () {
		// プレイヤーオブジェクト
		playerObj = GameObject.Find ("Player");
		//playerCamera = playerObj.transform.FindChild ("PlayerCamera").gameObject;

		// コーヒーカップオブジェクト
		redCup = GameObject.Find ("Cup0");
		blueCup = GameObject.Find ("Cup1");

		for (int i = 0; i < 4; i++) {
			cups [i] = GameObject.Find ("Cup" + i);
			cupScripts [i] = cups [i].GetComponent<Cup> ();
		}
		coffeeCupObj = GameObject.Find ("CoffeeCup");
		coffeeCupScript = coffeeCupObj.GetComponent<AroundRotation> ();
		
		// 回転盤オブジェクト
		redDisk = GameObject.Find("SpiningDisk1");
		blueDisk = GameObject.Find("SpiningDisk0");

		for (int i = 0; i<4; i++) {
			disks[i] = GameObject.Find("SpiningDisk" + i);
			diskScripts[i] = disks[i].transform.FindChild("Cylinder").GetComponent<Disk>();
		}

		// ブランコオブジェクト
		buranko = GameObject.Find ("Buranko0");
		burankoScript = buranko.transform.FindChild ("Cube").GetComponent<Buranko> ();
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void RideRedCup(){
		playerObj.transform.parent = redCup.transform;
		playerObj.GetComponent<OVRPlayerController> ().enabled = false;
		playerObj.transform.localPosition = new Vector3 (-1f, 0.8f, 0);
		
		float d = cups [0].transform.eulerAngles.y;
		playerObj.transform.eulerAngles = new Vector3 (0, 90.0f + d, 0);

		for (int i = 0; i < 4; i++) {
			cupScripts [i].operating = true;
		}
		coffeeCupScript.operating = true;
	}

	public void RideBlueCup(){
		playerObj.transform.parent = blueCup.transform;
		playerObj.GetComponent<OVRPlayerController> ().enabled = false;
		playerObj.transform.localPosition = new Vector3 (-1f, 0.8f, 0);

		float d = cups [1].transform.eulerAngles.y;
		playerObj.transform.eulerAngles = new Vector3 (0, 90.0f + d, 0);


		for (int i = 0; i < 4; i++) {
			cupScripts [i].operating = true;
		}
		coffeeCupScript.operating = true;
	}

	public void CrucifyRedDisk(){
		playerObj.transform.parent = redDisk.transform.FindChild ("Cylinder").transform;
		playerObj.GetComponent<OVRPlayerController> ().enabled = false;
		playerObj.transform.localPosition = new Vector3 (0, 2, 0);

		playerObj.transform.eulerAngles = new Vector3 (0, 180, 0);

		for (int i = 0; i < 4; i++) {
			diskScripts[i].operating = true;
		}
	}

	public void CrucifyBlueDisk(){
		playerObj.transform.parent = blueDisk.transform.FindChild ("Cylinder").transform;
		playerObj.GetComponent<OVRPlayerController> ().enabled = false;
		playerObj.transform.localPosition = new Vector3 (0, 2, 0);

		playerObj.transform.eulerAngles = new Vector3 (0, 180, 0);

		for (int i = 0; i < 4; i++) {
			diskScripts[i].operating = true;
		}	
	}

	public void RideBuranko(){
		playerObj.transform.parent = buranko.transform.FindChild ("Cube").transform;
		playerObj.GetComponent<OVRPlayerController> ().enabled = false;
		playerObj.transform.localPosition = new Vector3 (0, 0, 0);

		playerObj.transform.eulerAngles = new Vector3 (0, 90, 0);

		burankoScript.operating = true;
	}

	public void GetOffCup(){
		playerObj.transform.parent = null;
		playerObj.GetComponent<OVRPlayerController> ().enabled = true;
		playerObj.transform.position = new Vector3 (0, 1.0f, -15.0f);
		playerObj.transform.eulerAngles = new Vector3 (0, 0, 0);
		
		for (int i = 0; i < 4; i++) {
			cupScripts [i].operating = false;
		}
		coffeeCupScript.operating = false;

		for (int i = 0; i < 4; i++) {
			diskScripts[i].operating = false;
		}	

		burankoScript.operating = false;

	}

}
