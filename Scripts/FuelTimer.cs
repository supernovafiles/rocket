using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelTimer : MonoBehaviour
{
	public delegate void Timeout();
	public static event Timeout TimerTimeout;

    float waitTime = 5.0f;
    bool timerRunning = false;

	void OnEnable() {
		Rocket.EngineIgnited += onEngineIgnited;
	}
	
	void OnDisable() {
		Rocket.EngineIgnited -= onEngineIgnited;
	}
	void Start()
    {
        
    }

    
    void Update()
    {		
        if (timerRunning)
		{
			if (waitTime > 0)
			{
				waitTime -= Time.deltaTime;
			}
			else
			{
				waitTime = 0;
				timerRunning = false;
				if (TimerTimeout != null)
				{
					TimerTimeout();
				}
				
			}
		}
    }
	
	void onEngineIgnited() {
		timerRunning = true;
	}
}
