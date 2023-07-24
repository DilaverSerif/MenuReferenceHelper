using System.Collections.Generic;
using UnityEngine;

namespace MenuHelper
{
    public class MenuData : MonoBehaviour
    {
        #region Singleton

        private static MenuData _instance;

        public static MenuData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MenuData>();
                
                    if (_instance == null)
                    {
                        var go = new GameObject("MenuData");
                        _instance = go.AddComponent<MenuData>();
                    
                        Debug.LogWarning("MenuData is not found in the scene. Creating a new one.");
                    }
                }

                return _instance;
            }
        }

        #endregion

        public MenuContainer[] containers;
        public List<MenuItemObject> menuItems = new();
    }
}