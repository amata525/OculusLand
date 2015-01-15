using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	GameObject masterObj;

	Controller master;

	bool walking = true;
	bool riding = false;

	// Use this for initialization
	void Start () {
		masterObj = GameObject.Find ("GameMaster");

		master = masterObj.GetComponent<Controller> ();
	}

	// Update is called once per frame
	void Update () {

		// 歩いているならば
		if (walking) {
			RaycastHit hit;

			if (Physics.Raycast (this.transform.position, this.transform.forward, out hit, 2)) {
				if (hit.collider.tag == "GameController") {
					if (hit.collider.gameObject.name == "RedBoard") {
						hit.collider.gameObject.GetComponent<BoardColor>().index = 1;

						if (Input.GetKeyDown (KeyCode.E)) {
							master.RideRedCup ();
							riding = true;
							walking = false;
						}

					} else if (hit.collider.gameObject.name == "BlueBoard") {
						hit.collider.gameObject.GetComponent<BoardColor>().index = 1;

						if (Input.GetKeyDown (KeyCode.E)) {
							master.RideBlueCup ();
							riding = true;
							walking = false;
						}
					} else if (hit.collider.gameObject.name == "DiskRedBoard") {
						hit.collider.gameObject.GetComponent<BoardColor>().index = 1;
						
						if (Input.GetKeyDown (KeyCode.E)) {
							master.CrucifyRedDisk();
							riding = true;
							walking = false;
						}
					} else if (hit.collider.gameObject.name == "DiskBlueBoard") {
						hit.collider.gameObject.GetComponent<BoardColor>().index = 1;

						if (Input.GetKeyDown (KeyCode.E)) {
							master.CrucifyBlueDisk();
							riding = true;
							walking = false;
						}
					} else if (hit.collider.gameObject.name == "GreenBoard") {
						hit.collider.gameObject.GetComponent<BoardColor>().index = 1;
						
						if (Input.GetKeyDown (KeyCode.E)) {
							master.RideBuranko();
							riding = true;
							walking = false;
						}
					}

				}
			}

		// アトラクションに乗っているならば
		} else if (riding) {
			if (Input.GetKeyDown (KeyCode.E)) {
				master.GetOffCup ();
				riding = false;
				walking = true;
			}
		
		}
	}
	// github test
}