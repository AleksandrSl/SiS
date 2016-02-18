using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

[CustomEditor(typeof(TurnScriptOff))]
public class TurnScriptOffEditor : Editor {
    public string[] scripts;
    public string[] statusChoices = new string[]{"On", "Off" };

    string[] getAttachedScripts(GameObject obj)
    {
        int i = 0;
        string[] scripts = new string[obj.GetComponents<MonoBehaviour>().Length];
        foreach (var script in obj.GetComponents<MonoBehaviour>())
        {
            if (script.GetType().ToString() != "TurnScriptOff")
            {
                scripts.SetValue(script.GetType().ToString(), i++);
            }
        }
        return scripts;
    } 

    public override void OnInspectorGUI()
    {
        TurnScriptOff turnScriptOff = (TurnScriptOff)target;
        scripts = getAttachedScripts(turnScriptOff.gameObject);
        turnScriptOff.scriptIndex = EditorGUILayout.Popup(turnScriptOff.scriptIndex, scripts);
        turnScriptOff.scriptName = scripts[turnScriptOff.scriptIndex];
        turnScriptOff.statusIndex = EditorGUILayout.Popup(turnScriptOff.statusIndex, statusChoices);
    }
}
