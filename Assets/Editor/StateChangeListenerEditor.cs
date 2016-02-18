using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;


[CustomEditor(typeof(StateChangeListener))]
public class StateChangeListenerEditor : Editor {
    public string[] stateMachineChoices;
    public string[] stateChoices;

    private bool stateMachineChoicesDone = false; // To use reflection only once
    private bool stateChoicesDone = false;
   
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

    string[] getStates(Type enumType)
    {

        FieldInfo[] _states = enumType.GetFields(BindingFlags.Public | BindingFlags.Static); // Flags to remove value__;
        string[] _stateName = new string[_states.Length];
        int i = 0;
        foreach (var _state in _states)
        {
            _stateName.SetValue(_state.Name, i);
            i++;
        }
        return _stateName;
    }

    public override void OnInspectorGUI()
    
    {
        base.OnInspectorGUI();
        StateChangeListener stateChangeListener = target as StateChangeListener;
        if (!stateMachineChoicesDone)
        {
            stateMachineChoicesDone = true;
            Assembly ass = typeof(StateMachine<>).Assembly;
            stateMachineChoices = getClassesByNamespace("StateMachine", ass);
            //Debug.Log("StateMachnesLoaded");
        }
        stateChangeListener.stateMachineIndex = EditorGUILayout.Popup("State Machine",stateChangeListener.stateMachineIndex, stateMachineChoices);
        stateChangeListener.stateMachineName = stateMachineChoices[stateChangeListener.stateMachineIndex];

        if (!stateChoicesDone)
        {

            string _stateMachineClassName = "StateMachine." + stateChangeListener.stateMachineName;
            Type _stateMachineClass = typeof(StateChanger).Assembly.GetType(_stateMachineClassName);

            FieldInfo[] _stateMachineClassFields = _stateMachineClass.GetFields();
            object _stateMachine = _stateMachineClassFields[0].GetValue(null);

            string _enumName = _stateMachine.GetType().GetGenericArguments()[0].ToString();
            stateChangeListener.enumName = _enumName;
            Type _enumType = typeof(StateChanger).Assembly.GetType(_enumName);
            stateChoices = getStates(_enumType);

            stateChoicesDone = true;
            //Debug.Log("StateChoicesLoaded");
        }
        stateChangeListener.stateIndex = EditorGUILayout.Popup("Applicable State",stateChangeListener.stateIndex, stateChoices);
        stateChangeListener.stateName = stateChoices[stateChangeListener.stateIndex];


        
        

        if (GUI.changed)
        {
            stateChoicesDone = false;       //Load new states, when state machine changes
            EditorUtility.SetDirty(target);
        }

    }
      
}
