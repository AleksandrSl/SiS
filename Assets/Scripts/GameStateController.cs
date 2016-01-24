using UnityEngine;
using System.Collections;
using System;

public enum GameStates{
	Turn,
	Fire,
	WaitForHit,
	HitAnimation
	
}

namespace StateMachine
{
    public class GameStateController{

	    public static StateMachine<GameStates> gameStateMachine = new StateMachine<GameStates>(GameStates.Turn);
        
        


    }
}
