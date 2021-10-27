using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
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
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void onEngineIgnited() {
		gameObject.GetComponent<ParticleSystem>().enableEmission = true;
	}
	
	void onEngineHalted() {
		gameObject.GetComponent<ParticleSystem>().enableEmission = false;
	}
}
