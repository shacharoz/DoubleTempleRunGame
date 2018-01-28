using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    public string obstacleTagName = "Obstacle";

    public UnityEngine.Events.UnityEvent OnCollision;
    public UnityEngine.Events.UnityEvent OnLevelEnd;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == obstacleTagName)
        {
            OnCollision.Invoke();
        }

        if (other.tag == "Finish")
        {
            OnLevelEnd.Invoke();
        }
    }
}
