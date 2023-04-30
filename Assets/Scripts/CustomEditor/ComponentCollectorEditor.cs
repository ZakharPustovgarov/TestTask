using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(ComponentCollector))]
public class ComponentCollectorEditor : Editor
{
    public VisualTreeAsset m_UXML;

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        var def = new VisualElement();

        InspectorElement.FillDefaultInspector(def, serializedObject, this);

        root.Add(def);
        m_UXML.CloneTree(root);

        var collector = target as ComponentCollector;

        var xmlButton = root.Q<Button>("CollectButton");

        xmlButton.RegisterCallback<MouseUpEvent>((evt) => collector.CollectMyMonoBehaviours());

        return root;
    }
}
