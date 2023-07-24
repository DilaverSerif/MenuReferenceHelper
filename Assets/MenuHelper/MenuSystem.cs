using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace MenuHelper
{
    public static class MenuSystem
    {
        public static string Tag => MenuHelperSettings.Instance.titleTag;

        private static MenuContainer[] Containers
        {
            get => MenuData.Instance.containers;
            set => MenuData.Instance.containers = value;
        }

        private static List<MenuItemObject> MenuItems => MenuData.Instance.menuItems;

        public static Action OnMenuOpened;

#if UNITY_EDITOR


        [MenuItem("Tools/Menu System/Get Menu Items")]
        public static void PullContainers()
        {
            if (!EditorMenuExtension.IsTagDefined("MainCanvas"))
            {
                Debug.LogError("MainCanvas not found you need to create a canvas with tag MainCanvas");
                return;
            }

            var canvasTransform = GameObject.FindWithTag("MainCanvas");
            if (!canvasTransform)
            {
                Debug.LogError("MainCanvas not found you need to create a canvas with tag MainCanvas");
                return;
            }
            
            Containers = canvasTransform.GetComponentsInChildren<MenuContainer>(true);

            foreach (var container in Containers)
            {
                if (Containers.Where(container2 => container != container2).
                    All(container2 => container.transform.name != container2.transform.name)) continue;
                
                Debug.LogError("Container name must be unique");
                return;
            }
            
            MenuItems.Clear();
            MenuHelperEnumCreator.CheckEnumFile();
            foreach (var container in Containers)
            {
                container.menuSubItems = container.GetComponentsInChildren<MenuSubItem>(true);
            }

            var stringContainers = new string[Containers.Length];
            for (var i = 0; i < Containers.Length; i++)
                stringContainers[i] = Containers[i].transform.name;

            stringContainers.GenerateEnumFile("MenuContainers");

            for (var i = 0; i < stringContainers.Length; i++)
            {
                var stringItems =
                    new string[Containers[i].menuSubItems.Length];

                for (var j = 0; j < Containers[i].menuSubItems.Length; j++)
                {
                    stringItems[j] = Containers[i].menuSubItems[j].transform.name;
                    var itemEnum = Tag + stringContainers[i] + stringItems[j];

                    var menuItemObject = new MenuItemObject
                    {
                        menuItemName = itemEnum,
                        menuItemObject = Containers[i].menuSubItems[j].gameObject
                    };
                    MenuItems.Add(menuItemObject);
                }

                stringItems.GenerateEnumFile(stringContainers[i]);
            }

            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }

#endif

        public static T GetItemByEnum<T>(string itemKey) where T : Component
        {
            if (itemKey == null)
                return null;

            var item = MenuItems.Find(x => x.menuItemName == itemKey).menuItemObject;
            if (item == null)
            {
                Debug.LogError("Not Found Menu Item: " + itemKey);
                return null;
            }

            if (item.TryGetComponent(out T component))
                return component;

            Debug.LogError("Not Found Component");
            return null;
        }

        public static T GetMenuByEnum<T>(string itemKey) where T : Component
        {
            if (itemKey == null)
                return null;

            foreach (var container in Containers)
            {
                if (container.transform.name == itemKey)
                    if (container.TryGetComponent(out T component))
                    {
                        OnMenuOpened?.Invoke();
                        return component;
                    }
                    else
                    {
                        Debug.LogError("Not found Menu");
                        return null;
                    }
            }

            return null;
        }
    }
}