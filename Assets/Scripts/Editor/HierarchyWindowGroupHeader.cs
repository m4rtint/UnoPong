//-----------------------------------------------------------------------
// <copyright file="HierarchyWindowGroupHeader.cs" company="GOTTY">
//     Copyright (c) GOTTY. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using UnityEditor;
using UnityEngine;

/// <summary>
/// Hierarchy Window Group Header
/// </summary>
[InitializeOnLoad]
public static class HierarchyWindowGroupHeader
{
    static HierarchyWindowGroupHeader()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (gameObject != null && gameObject.name.StartsWith("---", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, Color.gray);
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("-", string.Empty).ToUpperInvariant());
        }
    }
}