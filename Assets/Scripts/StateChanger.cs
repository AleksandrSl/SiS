using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

using System.Collections.Generic;
using System.Linq;
using StateMachine;

public class StateChanger : MonoBehaviour {
    [SerializeField]
    private string _stateMachineName;
    public string stateMachineName { get { return _stateMachineName; } set { _stateMachineName = value; } }
    [SerializeField]
    private string _stateName;
    public string stateName { get { return _stateName; } set { _stateName = value; } }
    [SerializeField]
    private string _enumName;
    public string enumName { get { return _enumName; } set { _enumName = value; } }
    [SerializeField]
    private int _stateNum;
    public int stateNum { get { return _stateNum; } set { _stateNum = value; } }
    
    
    


    public void ChangeState()
    {
        
        string _stateMachineClassName = "StateMachine." + _stateMachineName;
        Type _stateMachineClass = typeof(StateChanger).Assembly.GetType(_stateMachineClassName);
        FieldInfo[] _stateMachine = _stateMachineClass.GetFields();
        var _val = _stateMachine[0].GetValue(null);
        Type _stateMachineBasicClass = typeof(StateChanger).Assembly.GetType(_val.GetType().FullName.ToString());
        PropertyInfo _curState = _stateMachineBasicClass.GetProperty("curState");
        Type _enumType = typeof(StateChanger).Assembly.GetType(_enumName);
        var enumValue = Enum.ToObject(_enumType, _stateNum);
        _curState.SetValue(_val, enumValue, null);
    }
    void Update()
    {
        Debug.Log(stateName);
    }
}
