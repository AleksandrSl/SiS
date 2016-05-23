using UnityEngine;
using UnityEngine.Events;
using System;
using System.Reflection;


public class StateChangeListener : MonoBehaviour {
    
    public UnityEvent onEnableState;
	public UnityEvent onDisableState;
    [HideInInspector]
    public string stateMachineName;
    [HideInInspector]
    public int stateMachineIndex;
    [HideInInspector]
    public string enumName;
    [HideInInspector]
    public string stateName;
    [HideInInspector]
    public int stateIndex;

    
    // Use this for initialization
    void Awake()
    {
		StateMachine<GameStates>.OnStateChange.Subscribe (OnStateChange);    
    }
    
    void OnStateChange(GameStates PreviousState, GameStates NextState)
    {
		if (NextState.ToString() == stateName)
        {
            onEnableState.Invoke();
		}
        if (PreviousState.ToString() == stateName)
        {
            onDisableState.Invoke();
        }
    }
}
