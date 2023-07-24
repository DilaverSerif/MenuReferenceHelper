using System;
using UnityEditor;
using UnityEngine;

namespace MenuHelper
{
    public static class MenuExtension
    {
        public static T GetMenuItem<T>(this Enum itemEnum) where T : Component
        {
            return MenuSystem.GetItemByEnum<T>(itemEnum.GetType().Name+itemEnum);
        }
        
        public static T GetMenu<T>(this EMenuContainers itemEnum) where T : Component
        {
            return MenuSystem.GetMenuByEnum<T>(itemEnum.ToString());
        }
    }

    public static class EditorMenuExtension
    {
        public static bool IsTagDefined(string tagName)
        {
#if UNITY_EDITOR
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty tagsProp = tagManager.FindProperty("tags");

            for (int i = 0; i < tagsProp.arraySize; i++)
            {
                SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
                if (t.stringValue == tagName)
                {
                    return true;
                }
            }
#endif

            return false;
        }
    }
}

