using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    bool inDoorRanger;
    public GameObject Door;

    void Awake() 
    {
        inDoorRanger = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Hero23"))
        {
          inDoorRanger = true;      
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Hero23"))
        {
            inDoorRanger = false;
        }
    }

    public void OpenDoor(bool hasKey) 
    { 
        if(inDoorRanger && hasKey)
        {
            Door.SetActive(false);
        }
    }
}
