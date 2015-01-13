using UnityEngine;
using System.Collections;

public class BoardColor : MonoBehaviour {

	public Material[] materials = new Material[2];
	public int index = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		renderer.material = materials [index];
		index = 0;
	}
}
