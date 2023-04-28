using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity.CodeEditor;
using UnityEngine;
using Component = UnityEngine.Component;


public class ComponentCollector : MonoBehaviour
{
    public ClassListLayout classLayout;
    [Space]
    [SerializeField] private List<Component> _myComponents = new List<Component>();

    public void CollectMyComponents()
    {
        _myComponents.Clear();

        _myComponents = GetComponents<MonoBehaviour>().ToList<Component>();

        classLayout.ShowList(_myComponents);
    }

}
