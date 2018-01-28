using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 1;

    public float XValueCenter = 0;
    private float widthOfPlane;
    private float oneStepSize;
    public Transform Plane;


    public PlayerImitationController FollowAvatar;

    public GameObject TrailPF;

	// Use this for initialization
	void Start () {
        widthOfPlane = Plane.localScale.x;
        oneStepSize = widthOfPlane / 3;
    }
	
	// Update is called once per frame
	void Update () {

        StepForward();
        
		if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveRight();
        }

        
    }

    private void StepForward()
    {
		Vector3 updatedPos = transform.position;
		updatedPos.Set(updatedPos.x, updatedPos.y, updatedPos.z + Speed );
		transform.position = updatedPos;
        
        Invoke("NotifyFollowPlayerForward", 1);
    }

    private void MoveLeft()
    {
		Vector3 updatedPos = transform.position;
		
        if (updatedPos.x - oneStepSize >= -oneStepSize) {
			updatedPos.Set (updatedPos.x - oneStepSize, updatedPos.y, updatedPos.z);
			transform.position = updatedPos;

            SendTransmission();
            Invoke("NotifyFollowPlayerLeft", 1);
        }
    }

    private void MoveRight()
    {
		Vector3 updatedPos = transform.position;

		if (updatedPos.x + oneStepSize <= oneStepSize) {
			updatedPos.Set (updatedPos.x + oneStepSize, updatedPos.y, updatedPos.z);
			transform.position = updatedPos;

            SendTransmission();
            Invoke("NotifyFollowPlayerRight", 1);
        }
    }

    private void NotifyFollowPlayerLeft()
    {
        FollowAvatar.UpdatePosition(new Vector3(-1, 0, 0));
    }

    private void NotifyFollowPlayerRight()
    {
        FollowAvatar.UpdatePosition(new Vector3(1, 0, 0));
    }

    private void NotifyFollowPlayerForward()
    {
        FollowAvatar.UpdatePosition(new Vector3(0, 0, Speed));
    }

    private void SendTransmission()
    {
        GameObject trail = Instantiate(TrailPF);
        trail.transform.position = this.transform.position;
        trail.GetComponent<TrailRenderer>().enabled = true;
    }




    public void OnDeath()
    {
        Speed /= 3;

        Invoke("RestartGame", 3);
    }


    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
