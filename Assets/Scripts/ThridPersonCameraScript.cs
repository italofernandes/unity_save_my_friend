using UnityEngine;
using System.Collections;

public class ThridPersonCameraScript : MonoBehaviour {

    public GameObject target;
    private Vector3 offSet;

	// Use this for initialization
	void Start () {
        offSet = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate() {
        float desireddAngle = target.transform.eulerAngles.y;
        
		Quaternion rotation = Quaternion.Euler(0, desireddAngle, 0);

        transform.position = target.transform.position - (rotation * offSet);

		transform.LookAt(target.transform);
    }
}
