using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

    public UnityEngine.Events.UnityEvent OnDeath;
    public UnityEngine.Events.UnityEvent OnFinish;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayerDied()
    {
        OnDeath.Invoke();
    }

    public void OnPlaneEnded()
    {
        OnFinish.Invoke();
    }

}
