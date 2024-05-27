using System.IO;
using JetBrains.Annotations;
using Tools.Editor.Template;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor.Templater
{
    using static TemplateConfig;

    internal static class TemplateCreator
    {
        [CanBeNull] private static string _packageDirectory;

        [MenuItem(InterfaceItem, priority = 40)]
        public static void CreateInterfaceMenuItem()
        {
            var path = GetTemplatePath(InterfaceTemplate);
            if (GuardTemplateExists(path))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, InterfaceClass);
        }

        [MenuItem(ScriptableObjectItem, priority = 40)]
        public static void CreateScriptableObjectMenuItem()
        {
            var path = GetTemplatePath(ScriptableObjectTemplate);
            if (GuardTemplateExists(path))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, ScriptableObjectClass);
        }

        [MenuItem(ClassItem, priority = 40)]
        public static void CreateClassMenuItem()
        {
            var path = GetTemplatePath(ClassTemplate);
            if (GuardTemplateExists(path))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, PureClass);
        }

        [MenuItem(StaticClassItem, priority = 40)]
        public static void CreateStaticClassMenuItem()
        {
            var path = GetTemplatePath(StaticClassTemplate);
            if (GuardTemplateExists(path))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, StaticClassClass);
        }

        [MenuItem(EnumItem, priority = 40)]
        public static void CreateEnumMenuItem()
        {
            var path = GetTemplatePath(EnumTemplate);
            if (GuardTemplateExists(path))
                return;

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, EnumClass);
        }

        private static bool GuardTemplateExists(string path)
        {
            return !File.Exists(path);
        }

        private static string GetTemplatePath(string templateName)
        {
            _packageDirectory ??= FindPackageFolder();
            if (_packageDirectory == null)
            {
                Debug.LogError("Failed to find package directory");
                return string.Empty;
            }

            return Path.Combine(_packageDirectory, templateName);
        }

        [CanBeNull]
        private static string FindPackageFolder()
        {
            var scriptGuids = AssetDatabase.FindAssets(Path.GetFileNameWithoutExtension(nameof(TemplateCreator)));

            if (scriptGuids.Length == 0)
            {
                return null;
            }

            var path = AssetDatabase.GUIDToAssetPath(scriptGuids[0]);
            return Path.GetDirectoryName(path);
        }
    }
}