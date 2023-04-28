using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourCollector : ScriptableObject
{
    public abstract List<Type> GetAllMonobehaviours();
}
