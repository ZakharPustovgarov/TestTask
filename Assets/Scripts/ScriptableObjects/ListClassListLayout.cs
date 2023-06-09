﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "ListLayout", menuName = "Class Layouts/List Layout", order = 51)]
    public class ListClassListLayout : ClassListLayout
    {
        public float windowMinWidth;
        public float windowMinLength;

        public override void SetComponentsList(List<MonoBehaviour> components)
        {
            ListEditorWindow.SetComponents(components);
        }

        public override void ShowList()
        {
            //Debug.Log("Invoking to show list");
            ListEditorWindow.ShowWindow( windowMinWidth, windowMinLength);
        }
    }
}
