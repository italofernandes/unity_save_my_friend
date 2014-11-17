using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent nav;
    static readonly string PLAYER_TAG = "Hero23";

	// Use this for initialization
	void Awake () {
        playerTransform = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
        nav = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        if (nav.enabled)
        {
          nav.SetDestination(playerTransform.position);
        }
 	}

    public void EnableMovemnt(bool isMovement) {
        nav.enabled = isMovement;
    }
}
