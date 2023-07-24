
#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace MenuHelper
{
    public static class MenuCustomExtension
    {
        public static readonly string menuPath = "MenuHelper/";
        
        [MenuItem("GameObject/UI/Helper Button",false,3)]
        static void AddBaseButton(MenuCommand menuCommand)
        {
            var baseButton = Resources.Load<GameObject>(menuPath+"HelperButton");
            if(baseButton == null)
                return;
            
            var button = PrefabUtility.InstantiatePrefab(baseButton) as GameObject;
            if(button == null)
                return;
            
            button.transform.SetParent(Selection.activeGameObject.transform,false);
        }
        
        [MenuItem("GameObject/UI/Helper Text",false,2)]
        static void AddBaseText(MenuCommand menuCommand)
        {
            var baseText = Resources.Load<GameObject>(menuPath+"HelperText");
            if(baseText == null)
                return;
            
            var text = PrefabUtility.InstantiatePrefab(baseText) as GameObject;
            if(text == null)
                return;
            
            text.transform.SetParent(Selection.activeGameObject.transform,false);
        }
        
        [MenuItem("GameObject/UI/Helper Image",false,1)]
        static void AddBaseImage(MenuCommand menuCommand)
        {
            var baseImage = Resources.Load<GameObject>(menuPath+"HelperImage");
            if(baseImage == null)
                return;
            
            var image = PrefabUtility.InstantiatePrefab(baseImage) as GameObject;
            if(image == null)
                return;
            
            image.transform.SetParent(Selection.activeGameObject.transform,false);
        }
        
        [MenuItem("GameObject/UI/Helper Menu",false,0)]
        static void AddBaseMenu(MenuCommand menuCommand)
        {
            var baseImage = Resources.Load<GameObject>(menuPath+"HelperMenu");
            if(baseImage == null)
                return;
            
            var image = PrefabUtility.InstantiatePrefab(baseImage) as GameObject;
            if(image == null)
                return;
            
            image.transform.SetParent(Selection.activeGameObject.transform,false);
        }
    }
}

#endif
