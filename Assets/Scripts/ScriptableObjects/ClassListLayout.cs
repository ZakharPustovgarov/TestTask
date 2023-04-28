using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{

    public abstract class ClassListLayout : ScriptableObject
    {
        public abstract void ShowList(List<Component> components);
    }
}
