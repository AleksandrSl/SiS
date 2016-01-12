using UnityEngine;
using System.Collections;
using System;
public enum GameStates{
	Turn,
	Fire,
	WaitForHit,
	HitAnimation
	
}


public class GameStateController:MonoBehaviour {

	public static StateMachine<GameStates> gameStateMachine = new StateMachine<GameStates>(GameStates.Turn);


}
//Turning, WaitingForHit, HitAnimation
//а еще у него есть статическое поле типа GameStateMachine, которое в Awake() назначается на себя.
//	так же он проверяет, что больше нет других объектов типа GameStateMachine. Если есть, кричит об этом в консоль.