using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class StateMachine<T> where T : struct, IComparable, IConvertible, IFormattable 
{
	public static Message<T, T> OnStateChange = new Message<T, T>();

	private T _curState;
	public StateMachine(T defaultState){
		_curState = defaultState;
        Debug.Log("I'm created");
	}

	public T curState{
		get{
			return _curState;
		}
		set{
			if (!(value.Equals(_curState))){
				StateMachine<T>.OnStateChange.Say(_curState, value);
				_curState = value;
			}
		}

	}
    
	public void resetState(T noneState){
		T transientState_ = _curState;
		StateMachine<T>.OnStateChange.Say(_curState, noneState );
		_curState = noneState;
		_curState = transientState_;
	}
}