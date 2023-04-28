using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Unity.CodeEditor;
using UnityEngine;
using Component = UnityEngine.Component;


public class ComponentCollector : MonoBehaviour
{
    public ClassListLayout classLayout;
    [Space]
    [SerializeField] private List<string> _allMonobehsNames = new List<string>();
    [SerializeField] private List<Component> _myComponents = new List<Component>();

    private List<Type> _allMonobehs = new List<Type>();


    private void OnValidate()
    {
        UpdateMonobehsList();
    }

    public void CollectMyComponents()
    {
        _myComponents.Clear();
        Debug.Log("Starting collecting my components");
        foreach (var monobeh in _allMonobehs) 
        {
            Component buff = null;

            if(TryGetComponent(monobeh, out buff))
            {
                //Debug.Log($"{monobeh.FullName} ?= {buff.GetType().FullName}");
                if (monobeh.FullName != buff.GetType().FullName) continue;

                _myComponents.Add(buff);
            }
        }
        Debug.Log("Ended collecting my components");
        classLayout.ShowList(_myComponents);
    }

    private void UpdateMonobehsList()
    {
        ClearTypes();

        var assem = Assembly.GetExecutingAssembly();

        foreach (var type in assem.DefinedTypes)
        {
            var baseType = type.BaseType;

            if (baseType != typeof(MonoBehaviour))
            {
                bool monoCheck = false;

                while (baseType != null)
                {
                    baseType = baseType.BaseType;

                    if (baseType == typeof(MonoBehaviour))
                    {
                        monoCheck = true;
                        break;
                    }
                }

                if (monoCheck)
                {
                    AddType(type);
                }
            }
            else
            {
                AddType(type);
            }

        }

        Debug.Log("Ended collecting all monobehs");
    }

    private void ClearTypes()
    {
        _allMonobehs.Clear();
        _allMonobehsNames.Clear();
    }

    private void AddType(Type type)
    {
        _allMonobehs.Add(type);
        _allMonobehsNames.Add(type.Name);
    }

}
