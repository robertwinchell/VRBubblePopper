using UnityEngine;
using System.Collections;

public class EnaDisable : MonoBehaviour {

	public GameObject object1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.F1)) {
			object1.SetActive(!object1.activeSelf);
		}
	}
}
