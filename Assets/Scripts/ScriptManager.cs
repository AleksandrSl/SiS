using UnityEngine;
using System.Collections;

public class ScriptManager : MonoBehaviour {

	public  TouchPosition touchPosition;
	public FireButton fireButton;

	void Awake(){
		//StateMachine<GameStates>.OnStateChange.Subscribe (TurnScriptOff_On);
		//GameStateController.gameStateMachine.OnStateChange.Subscribe (TurnScriptOff); // error CS0176: Static member `StateMachine<GameStates>.OnStateChange' cannot be accessed with an instance reference, qualify it with a type name instead
	}

	void TurnScriptOff_On(GameStates PreviousState, GameStates NextState){

		if (NextState == GameStates.Fire) {
			Debug.Log ("RotationTouch Script is off");
			touchPosition.enabled = false;
			//this.enabled = false;
		}
		if (NextState == GameStates.WaitForHit) {
			Debug.Log("FireButton script is off");
			fireButton.enabled = false; //Как отключить скрипты без апдэйт я пока не смотрел, поэтому не работает))
		}
	}
		 
}