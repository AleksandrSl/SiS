using UnityEngine;
using System;
using System.Reflection;


public class StateChanger: MonoBehaviour {

    public string stateMachineName;
    public int stateMachineIndex;

    public string enumName;

    public string stateName;
    public int stateIndex;

    private PropertyInfo _curState;
    private object _stateMachine;
    private object _state;

    public void ChangeState()
    {
        _curState.SetValue(_stateMachine, _state, null);
    }
    /// <summary>
    /// 
    /// </summary>
    public void Awake()  
    {
        string _stateMachineClassName = "StateMachine." + stateMachineName;
        var _stateMachineClass = typeof(StateChanger).Assembly.GetType(_stateMachineClassName);
        FieldInfo[] _stateMachineClassFields = _stateMachineClass.GetFields();
        _stateMachine = _stateMachineClassFields[0].GetValue(null);
        var _stateMachineBasicClass = typeof(StateChanger).Assembly.GetType(_stateMachine.GetType().FullName.ToString());
        _curState = _stateMachineBasicClass.GetProperty("curState");
        var _enumType = typeof(StateChanger).Assembly.GetType(enumName);
        _state = Enum.ToObject(_enumType, stateIndex);
        Debug.Log(_state);
    }
}


 
         
         
         
