using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ClassListLayout : ScriptableObject
    {
        public abstract void ShowList();
        public abstract void SetComponentsList(List<Component> components);
    }
}
