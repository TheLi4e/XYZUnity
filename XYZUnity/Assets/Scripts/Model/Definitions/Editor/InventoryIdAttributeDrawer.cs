﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts.Model.Definitions.Editor
{
    [CustomPropertyDrawer(typeof(InventoryIdAttribute))]
    public class InventoryIdAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var defs = DefsFacade.Instance.Items.itemsForEditor;
            var ids = new List<string>();
            foreach (var item in defs)
            {
                ids.Add(item.Id);
            }
            var index = Mathf.Max(ids.IndexOf(property.stringValue), 0);
            index = EditorGUI.Popup(position, property.displayName, index, ids.ToArray());

            property.stringValue = ids[index];
        }
    }
}
