using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	GameObject masterObj;

	Controller master;

	GameObject redBoard;
	GameObject blueBoard;

	BoardColor redBoardColor;
	BoardColor blueBoardColor;

	bool walking = true;
	bool riding = false;

	// Use this for initialization
	void Start () {
		masterObj = GameObject.Find ("GameMaster");

		master = masterObj.GetComponent<Controller> ();

		redBoard = GameObject.Find("RedBoard");
		blueBoard = GameObject.Find("BlueBoard");

		redBoardColor = redBoard.GetComponent<BoardColor> ();
		blueBoardColor = blueBoard.GetComponent<BoardColor> ();
	}

	// Update is called once per frame
	void Update () {

		// 歩いているならば
		if (walking) {
			RaycastHit hit;

			if (Physics.Raycast (this.transform.position, this.transform.forward, out hit, 2)) {
				if (hit.collider.tag == "GameController") {
					if (hit.collider.gameObject.name == "RedBoard") {
						redBoardColor.index = 1;

						if (Input.GetKeyDown (KeyCode.E)) {
							master.RideRedCup ();
							riding = true;
							walking = false;
						}

					} else if (hit.collider.gameObject.name == "BlueBoard") {
						blueBoardColor.index = 1;

						if (Input.GetKeyDown (KeyCode.E)) {
							master.RideBlueCup ();
							riding = true;
							walking = false;
						}
					}

				} else {
					redBoardColor.index = 0;
					blueBoardColor.index = 0;
				}

			} else {
				redBoardColor.index = 0;
				blueBoardColor.index = 0;
			}
		// カップに乗っているならば
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