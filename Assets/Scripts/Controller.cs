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

	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find ("Player");
		//playerCamera = playerObj.transform.FindChild ("PlayerCamera").gameObject;

		redCup = GameObject.Find ("Cup0");
		blueCup = GameObject.Find ("Cup1");

		for (int i = 0; i < 4; i++) {
			cups [i] = GameObject.Find ("Cup" + i);
			cupScripts [i] = cups [i].GetComponent<Cup> ();
		}
		coffeeCupObj = GameObject.Find ("CoffeeCup");
		coffeeCupScript = coffeeCupObj.GetComponent<AroundRotation> ();

		redDisk = GameObject.Find("SpiningDisk1");
		blueDisk = GameObject.Find("SpiningDisk0");

		for (int i = 0; i<4; i++) {
			disks[i] = GameObject.Find("SpiningDisk" + i);
			diskScripts[i] = disks[i].GetComponent<Disk>(); //　ここ子オブジェクトに変える
		}
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
		playerObj.transform.localPosition = new Vector3 (0, 0, 0);

		for (int i = 0; i < 4; i++) {
			diskScripts[i].operating = true;
		}
	}

	public void CrucifyBlueDisk(){
		playerObj.transform.parent = blueDisk.transform.FindChild ("Cylinder").transform;
		playerObj.GetComponent<OVRPlayerController> ().enabled = false;
		playerObj.transform.localPosition = new Vector3 (0, 0, 0);
		
		for (int i = 0; i < 4; i++) {
			diskScripts[i].operating = true;
		}	
	}

	public void GetOffCup(){
		playerObj.transform.parent = null;
		playerObj.GetComponent<OVRPlayerController> ().enabled = true;
		playerObj.transform.position = new Vector3 (0, 1.0f, -12.0f);
		playerObj.transform.eulerAngles = new Vector3 (0, 0, 0);
		
		for (int i = 0; i < 4; i++) {
			cupScripts [i].operating = false;
		}
		coffeeCupScript.operating = false;
	}

}
