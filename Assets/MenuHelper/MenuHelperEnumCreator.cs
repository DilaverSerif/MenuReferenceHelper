using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MenuHelper
{
    public static class MenuHelperEnumCreator
    {
#if UNITY_EDITOR
        private static readonly string EnumPath = MenuHelperSettings.GetDefaultEnumPath();
        private static string Tag => MenuHelperSettings.Instance.titleTag;
        public static void CheckEnumFile()
        {
            if (File.Exists(EnumPath+"/MenuItems.cs"))
                File.Delete(EnumPath+"/MenuItems.cs");
        }
        public static void GenerateEnumFile(this string[] values, string enumName)
        {
            var filePath = Path.Combine(EnumPath, "MenuItems.cs");
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"public enum {Tag}{enumName}");
                writer.WriteLine("{ None = -1,");

                for (var i = 0; i < values.Length; i++)
                    writer.WriteLine($"    {values[i]} = {i},");

                writer.WriteLine("}");
            }

            AssetDatabase.Refresh();
        }

#endif
    }
}