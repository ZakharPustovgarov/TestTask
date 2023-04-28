using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "ListLayout", menuName = "Class Layouts/List Layout", order = 51)]
    public class ListClassListLayout : ClassListLayout
    {
        public float windowMinWidth;
        public float windowMinLength;

        public override void ShowList(List<Component> components)
        {
            Debug.Log("Invoking to show list");
            ClassListEditor.ShowGridWindow(components, windowMinWidth, windowMinLength);
        }
    }
}
