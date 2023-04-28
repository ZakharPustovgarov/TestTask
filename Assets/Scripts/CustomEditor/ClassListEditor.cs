﻿using System;
using System.Collections.Generic;
using System.Linq;
using Unity.CodeEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class ClassListEditor : EditorWindow
    {
        private static List<Component> _shownComponents;

        public static void ShowGridWindow(List<Component> components, float windowWidth, float windowLength)
        {
            Debug.Log("Starting to open window");
            _shownComponents = components;
            EditorWindow wnd = GetWindow<ClassListEditor>();

            wnd.minSize = new Vector2(windowWidth, windowLength);
            wnd.titleContent = new GUIContent("Class List");

            Debug.Log("Window opened");
        }

        public void CreateGUI()
        {
            var wrapper = new VisualElement();

            rootVisualElement.Add(wrapper);

            var classList = new ListView();
            wrapper.Add(classList);

            classList.makeItem = () => new Label();
            classList.bindItem = (item, index) =>
            {
                (item as Label).text = _shownComponents[index].GetType().Name;
            };
            classList.itemsSource = _shownComponents;

            classList.itemsChosen += OnComponentSelectionChange;

            Debug.Log("Gui for window created");
        }

        private void OnComponentSelectionChange(IEnumerable<object> selectedItems)
        {
            var selectedComponent = selectedItems.First() as Component;
            if (selectedComponent == null)
                return;

            CodeEditor.CurrentEditor.OpenProject(TypeUtility.ReturnFilePathByType(selectedComponent.GetType()), 0, 0);
        }
    }
}