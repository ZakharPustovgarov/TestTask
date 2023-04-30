using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity.CodeEditor;
using Unity.VisualScripting;
using UnityEngine;
using Component = UnityEngine.Component;


public class ComponentCollector : MonoBehaviour
{
    public ClassListLayout classLayout;
    [Space]
    [SerializeField] private List<MonoBehaviour> _myComponents = new List<MonoBehaviour>();

    private void OnValidate()
    {
        classLayout.SetComponentsList(_myComponents);
    }

    public void CollectMyMonoBehaviours()
    {
        _myComponents.Clear();

        _myComponents = GetComponents<MonoBehaviour>().ToList();

        MakeMonoBehaviourListDistinct();

        classLayout.SetComponentsList(_myComponents);

        classLayout.ShowList();
    }


    private void MakeMonoBehaviourListDistinct()
    {
        for(int i = 0; i < _myComponents.Count - 1; i++)
        {
            for(int j = i+1; j < _myComponents.Count;)
            {
                //Debug.Log($"{i} vs {j}");
                if (_myComponents[i].GetType().Name == _myComponents[j].GetType().Name)
                {
                    _myComponents.RemoveAt(j);
                }
                else
                {
                    j++;
                }
            }
        }
    }
}
