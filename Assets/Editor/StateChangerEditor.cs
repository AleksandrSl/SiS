using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

[CustomEditor(typeof(StateChanger))]
public class StateChangerEditor: Editor{
	public int _stateMachineIndex;
    
    public int _stateIndex ;
    public string[] _stateMachineChoices;
    public string[] _stateChoices;
   
    
    
    
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="@namespace"></param>
    /// <returns></returns>
    string[] getClassesByNamespace(string @namespace)
    {
        //string @namespace = "StateMachine";
        Assembly ass = typeof(StateChanger).Assembly;
        var q = from t in ass.GetTypes()
                where t.IsClass && t.Namespace == @namespace
                select t;

        string[] _classes = new string[q.Count()];
        int i = 0;
        q.ToList().ForEach(t => _classes.SetValue(t.Name, i++));
        return _classes;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="enumType"></param>
    /// <returns></returns>
    string[] getStates(Type enumType)
    {
        
        FieldInfo[] _states= enumType.GetFields(BindingFlags.Public | BindingFlags.Static); // Flags to remove value__;
        string[] _stateName = new string[_states.Length];
        int i = 0;
        foreach (var _state in _states)
        {
            
            _stateName.SetValue(_state.Name, i);
            i++;
        }
        return _stateName; 
    }

    
    public override void OnInspectorGUI(){
        StateChanger stateChanger = (StateChanger)target;
        _stateMachineChoices = getClassesByNamespace("StateMachine");
		_stateMachineIndex = EditorGUILayout.Popup (_stateMachineIndex, _stateMachineChoices);
        stateChanger.stateMachineName = _stateMachineChoices[_stateMachineIndex];

        string _stateMachineClassName ="StateMachine." + _stateMachineChoices[_stateMachineIndex];
        Type _stateMachineClass = typeof(StateChanger).Assembly.GetType(_stateMachineClassName);
        
        
        
        FieldInfo[] _stateMachine = _stateMachineClass.GetFields();
        var _val = _stateMachine[0].GetValue(null);
        
        string _enumName = _val.GetType().GetGenericArguments()[0].ToString();
        stateChanger.enumName = _enumName;
        Type _enumType = typeof(StateChanger).Assembly.GetType(_enumName);
        //stateChanger._enum = _enumType;
        _stateChoices = getStates(_enumType);
        _stateIndex = EditorGUILayout.Popup(_stateIndex, _stateChoices );
        stateChanger.stateName = _stateChoices[_stateIndex];
        stateChanger.stateNum = _stateIndex;
        if (GUI.changed)
            EditorUtility.SetDirty(stateChanger);

    }
}
