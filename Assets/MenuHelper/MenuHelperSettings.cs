using UnityEditor;
using UnityEngine;

namespace MenuHelper
{
    [CreateAssetMenu(fileName = "MenuHelperSettings", menuName = "MenuHelper/MenuHelperSettings")]
    public class MenuHelperSettings : ScriptableObject
    {
        public static string GetDefaultEnumPath()
        {
            var path = AssetDatabase.GetAssetPath(Instance);
            path = path.Replace("MenuHelperSettings.asset", "");
            return path;
        }

        public static MenuHelperSettings Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = Resources.Load<MenuHelperSettings>("MenuHelper/MenuHelperSettings");
                
                if (_instance == null)
                {
                    Debug.LogError("Missing MenuHelperSettings.asset you must create one");
                    return null;
                }
                
                return _instance;
            }
        }

        public string titleTag = "E";
        private static MenuHelperSettings _instance;
    }
}