using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour {

    private Transform target;

    private float startTime;
    private float endAfter = 1;

    private float speed;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("PlayerMirror").transform;

        startTime = Time.time;

        speed = Vector3.Distance (target.position, transform.position) / endAfter;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime >= endAfter)
        {
            transform.position = target.position;
            Destroy(this.gameObject);
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
