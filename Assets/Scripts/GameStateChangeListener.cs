using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameStateChangeListener : MonoBehaviour {

	public UnityEvent onEnableState;
	public UnityEvent onDisableState;
	public GameStates applicableState;
	// Use this for initialization
	void Awake(){
		StateMachine<GameStates>.OnStateChange.Subscribe (OnStateChange);
	}
	void OnStateChange(GameStates PreviousState, GameStates NextState){
		if (NextState == GameStates.Fire) {
			Debug.Log ("RotationTouch Script is off");
			onDisableState.Invoke();
			//this.enabled = false;
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
