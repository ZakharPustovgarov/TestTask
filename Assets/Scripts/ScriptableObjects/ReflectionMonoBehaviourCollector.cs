using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "ReflectionMonoBehaviourCollector", menuName = "MonoBehaviours Collectors/Reflection MonoBehaviour Collector", order = 52)]
public class ReflectionMonoBehaviourCollector : MonoBehaviourCollector
{
    public override List<Type> GetAllMonobehaviours()
    {
        List<Type> types = new List<Type>();

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
                    types.Add(type);
                }
            }
            else
            {
                types.Add(type);
            }

        }

        return types;
    }
}
