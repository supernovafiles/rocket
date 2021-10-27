using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
	public delegate void Ignited();
	public static event Ignited EngineIgnited;
	public delegate void Halted();
	public static event Halted EngineHalted;


	Transform[] rocketParts;
	
	private PlayerControls Controls;
	float thrustInput;
	float thrustSpeed;
	bool engineStarted = false;
	bool engineRunning = false;
	Rigidbody rocketRigidbody;
	float windSpeed;
	
	float maxHeight = 0f;
	
	void OnEnable() {
		FuelTimer.TimerTimeout += onTimerTimeout;
	}
	
	void OnDisable() {
		FuelTimer.TimerTimeout -= onTimerTimeout;
	}
	
	void Start()
    {
		rocketParts = GetComponentsInChildren<Transform>();
		rocketRigidbody = GetComponent<Rigidbody>();
		rocketRigidbody.isKinematic = true;
		thrustSpeed = 80f;
		windSpeed = 0.5f;

        Controls = new PlayerControls();
		Controls.Enable();
		
		Controls.Keyboard.Thrust.performed += ctx =>
		{
			thrustInput = ctx.ReadValue<float>();
			rocketRigidbody.isKinematic = false;
			engineStarted = true;
			engineRunning = true;
			rocketRigidbody.isKinematic = false;
			EngineIgnited.Invoke();
		};
		Controls.Keyboard.Thrust.canceled -= ctx =>
		{
			thrustInput = ctx.ReadValue<float>();
		};
		Controls.Keyboard.Detach.performed += ctx =>
		{
			StartCoroutine(DetachStage());
		};
		Controls.Keyboard.Detach.canceled -= ctx =>
		{
			StartCoroutine(DetachStage());
		};
		Controls.Keyboard.Parachute.performed += ctx =>
		{
			ActivateParachute();
		};
		Controls.Keyboard.Parachute.performed -= ctx =>
		{
			ActivateParachute();
		};
    }
   
    void Update()
    {
        Thrust();
		DefineMaxHeight();
		Wind();
    }
	
	void onTimerTimeout() {
		engineRunning = false;
		EngineHalted.Invoke();
	}
	
	private void DefineMaxHeight() {
		if (rocketRigidbody.transform.position.y > maxHeight) {
			maxHeight = rocketRigidbody.transform.position.y;
		}
		// Debug.Log(maxHeight);
	}
	
	private void Thrust() {
		if (engineStarted & engineRunning) {
			rocketRigidbody.AddForce(transform.up * thrustSpeed);
		}
		else if (engineStarted & !engineRunning)
		{
			if (rocketRigidbody.velocity.y < 0)
			{
				// Debug.Log(engineRunning);
			}
		}
		
	}
	
	IEnumerator DetachStage() {
		if (engineStarted & engineRunning) {
			Transform secondStage = rocketParts[1];
			Transform parachute = rocketParts[4];
			Transform firstStage = rocketParts[5];
			firstStage.transform.parent = null;
			
			EngineHalted.Invoke();
			engineRunning = false;
			
			parachute.gameObject.GetComponent<FixedJoint>();
			
			rocketRigidbody.GetComponent<BoxCollider>().enabled = false;
			
			firstStage.gameObject.AddComponent<Rigidbody>();
			BoxCollider firstStageCollider = firstStage.gameObject.GetComponent<BoxCollider>();
			
			yield return new WaitForSeconds(.2f);
			
			firstStageCollider.enabled = true;
			
			// secondStage.gameObject.AddComponent<Rigidbody>();
			BoxCollider secondStageCollider = secondStage.gameObject.GetComponent<BoxCollider>();
			secondStageCollider.enabled = true;
			EngineIgnited.Invoke();
			engineRunning = true;
		}
	}
	
	void ActivateParachute() {
		if (engineStarted & !engineRunning) {
			Transform parachute = rocketParts[4];
			MeshRenderer parachuteMesh = parachute.gameObject.GetComponent<MeshRenderer>();
			parachuteMesh.enabled = true;
			rocketRigidbody.drag = 0.8f;
		}
	}
	
	void Wind() {
		if (rocketRigidbody.transform.position.y > 0) {
			rocketRigidbody.AddForce(transform.forward * windSpeed);
		}
		
	}
}
