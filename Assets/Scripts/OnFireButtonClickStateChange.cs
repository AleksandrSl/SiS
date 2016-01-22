using UnityEngine;
using System.Collections;
using StateMachine;

public class OnFireButtonClickStateChange : MonoBehaviour {

	public void OnClick(){
		GameStateController.gameStateMachine.curState = GameStates.Fire;
		GameStateController.gameStateMachine.curState = GameStates.WaitForHit;//Их наверное можно в один объединить
		
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
