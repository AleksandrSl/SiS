using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using StateMachine;

public class StateChanger : MonoBehaviour {
    public string _stateMachineName;
    public string _stateName;
    public string _enumName;
    public int _stateNum;
    
    


    public void ChangeState(){

        string _stateMachineClassName = "StateMachine." + _stateMachineName;
        Type _stateMachineClass = typeof(StateChanger).Assembly.GetType(_stateMachineClassName);
        FieldInfo[] _stateMachine = _stateMachineClass.GetFields();
        
        var _val = _stateMachine[0].GetValue(null);
       

        
        Type _stateMachineBasicClass = typeof(StateChanger).Assembly.GetType("StateMachine`1");
        PropertyInfo _curState = _stateMachineBasicClass.GetProperty("curState");

        Type _enumType = typeof(StateChanger).Assembly.GetType(_enumName);
        var enumValue = Enum.ToObject(_enumType, _stateNum);
        Debug.Log(_stateMachine[0].GetValue(null));
        _curState.SetValue(_val, enumValue, null);
    }
    void Start() {
        ChangeState();
    }
}
