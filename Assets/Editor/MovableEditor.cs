using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;
using Assets.Scripts;


    [CustomEditor(typeof (Movable), true)]
    public class MovableEditor : Editor
    {

        public string[] ClassChoices;
        public string[] MethodChoices;

        private bool _classChoiceDone = false;
        private bool _methodChoiceDone = false;

        string[] getClassesByAssembly(Assembly ass)
        {
            var q = from t in ass.GetTypes()
                where t.IsClass && !(t.IsSubclassOf(typeof(Movable)))
                select t;

            string[] _classes = new string[q.Count()];
            int i = 0;
            q.ToList().ForEach(t => _classes.SetValue(t.Name, i++));
            return _classes;
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Movable movable = target as Movable;
            if (!_classChoiceDone)
            {
                _classChoiceDone = true;
                Assembly ass = typeof(Movable).Assembly ; // Delete Movement from this list
                ClassChoices = getClassesByAssembly(ass);
            }
            movable.ClassIndex = EditorGUILayout.Popup("Class", movable.ClassIndex, ClassChoices);
            movable.ClassName = ClassChoices[movable.ClassIndex];
            if (!_methodChoiceDone)
            {
                _methodChoiceDone = true;
                Type Class = typeof (Movable).Assembly.GetType(movable.ClassName);
                var classMethods = from t in Class.GetMethods()
                                            where t.ReturnType == typeof(void)
                                            select t;
                MethodChoices = new string[classMethods.Count()];
                int i = 0;
                classMethods.ToList().ForEach(t => MethodChoices.SetValue(t.Name, i++));
                Debug.Log(MethodChoices);
                
            }
            movable.MethodIndex = EditorGUILayout.Popup("Method", movable.MethodIndex, MethodChoices);
            movable.MethodName = MethodChoices[movable.MethodIndex];


            if (GUI.changed)
            {
                _classChoiceDone = false;
                _methodChoiceDone = false;
                EditorUtility.SetDirty(target);
            }
        }
    }
