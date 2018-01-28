using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImitationController : MonoBehaviour {

    public Transform MainPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(MainPlayer);
        

    }

    public void UpdatePosition(Vector3 updateVector)
    {
        Vector3 updatedPos = transform.position + updateVector;
        transform.position = updatedPos;
    }
    
}
