using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

[CustomEditor(typeof(StateChanger))]
public class StateChangerEditor: Editor{
	
    public string[] stateMachineChoices;
    public string[] stateChoices;

    private bool stateMachineChoicesDone = false; // To use reflection as rearely as possible
    private bool stateChoicesDone = false;  // --..--

    /// <summary>
    /// 
    /// </summary>
    /// <param name="@namespace">string</param>
    /// <param name="ass">Assembly</param>
    /// <returns>string[] of classes' names marked by chosen namespace in chosen assembly</returns>
    string[] getClassesByNamespace(string @namespace, Assembly ass)
    {
        
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
    /// <returns>string[] of states' names in chosen enum</returns>
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
        
        StateChanger stateChanger = target as StateChanger;
        if (!stateMachineChoicesDone)
        {
            stateMachineChoicesDone = true;
            Assembly ass = typeof(StateMachine<>).Assembly;
            stateMachineChoices = getClassesByNamespace("StateMachine", ass);
            //Debug.Log("StateMachnesLoaded");
        }
		stateChanger.stateMachineIndex = EditorGUILayout.Popup ("State Machine",stateChanger.stateMachineIndex, stateMachineChoices);
        stateChanger.stateMachineName = stateMachineChoices[stateChanger.stateMachineIndex];
        
        if (!stateChoicesDone)
        {
            
            string _stateMachineClassName = "StateMachine." + stateChanger.stateMachineName;
            Type _stateMachineClass = typeof(StateChanger).Assembly.GetType(_stateMachineClassName);

            FieldInfo[] _stateMachineClassFields = _stateMachineClass.GetFields();
            object _stateMachine = _stateMachineClassFields[0].GetValue(null);

            string _enumName = _stateMachine.GetType().GetGenericArguments()[0].ToString();
            stateChanger.enumName = _enumName;
            Type _enumType = typeof(StateChanger).Assembly.GetType(_enumName);
            stateChoices = getStates(_enumType);

            stateChoicesDone = true;
            //Debug.Log("StateChoicesLoaded");
        }
        stateChanger.stateIndex = EditorGUILayout.Popup("State",stateChanger.stateIndex, stateChoices );
        stateChanger.stateName = stateChoices[stateChanger.stateIndex];
        if (GUI.changed)
        {
            stateChoicesDone = false;       //Load new states, when state machine changes
            EditorUtility.SetDirty(target);
        }
        

    }
}
