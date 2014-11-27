using UnityEngine;
using System.Collections;

public class DoorTrapScript : MonoBehaviour {

	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag.Equals("Hero23")) {
			//Refactor to Animation;
			door.SetActive(false);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag.Equals("Hero23")) {
			//Refactor to Animation;
			door.SetActive(true);
		}
	}
}
