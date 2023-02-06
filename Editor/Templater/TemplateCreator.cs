using System.IO;
using UnityEditor;

#if UNITY_EDITOR

namespace Editor.Templater {
    using static TemplateConfig;


    internal static class TemplateCreator {
        [MenuItem(InterfaceItem, priority = 40)]
        public static void CreateInterfaceMenuItem() {
            if (GuardTemplateExists(InterfaceTemplate))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(InterfaceTemplate, InterfaceClass);
        }

        [MenuItem(ScriptableObjectItem, priority = 40)]
        public static void CreateScriptableObjectMenuItem() {
            if (GuardTemplateExists(ScriptableObjectTemplate))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(ScriptableObjectTemplate, ScriptableObjectClass);
        }

        [MenuItem(ClassItem, priority = 40)]
        public static void CreateClassMenuItem() {
            if (GuardTemplateExists(ClassTemplate))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(ClassTemplate, PureClass);
        }

        [MenuItem(StaticClassItem, priority = 40)]
        public static void CreateStaticClassMenuItem() {
            if (GuardTemplateExists(StaticClassTemplate))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(StaticClassTemplate, StaticClassClass);
        }

        [MenuItem(EnumItem, priority = 40)]
        public static void CreateEnumMenuItem() {
            if (GuardTemplateExists(EnumTemplate))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(EnumTemplate, EnumClass);
        }

        static bool GuardTemplateExists(string path) {
            return !File.Exists(path);
        }
    }
}
#endif