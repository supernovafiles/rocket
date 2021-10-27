using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustSound : MonoBehaviour
{
    void OnEnable() {
		Rocket.EngineIgnited += onEngineIgnited;
		Rocket.EngineHalted += onEngineHalted;
	}
	
	void OnDisable() {
		Rocket.EngineIgnited -= onEngineIgnited;
		Rocket.EngineHalted -= onEngineHalted;
	}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void onEngineIgnited() {
		gameObject.GetComponent<AudioSource>().Play();
	}
	
	void onEngineHalted() {
		gameObject.GetComponent<AudioSource>().Stop();
	}
}
