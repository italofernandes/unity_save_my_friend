using UnityEngine;
using System.Collections;

public class KeyControllerScript : MonoBehaviour {

    void OnTriggerEnter(Collider other) 
    {
        GameObject go = other.gameObject;

        if(go.tag.Equals("Hero23"))
        {
            PlayerController playerController = go.GetComponent<PlayerController>();

            playerController.GivePlayerTheKey();

            Destroy(gameObject);
        }
    }
}
