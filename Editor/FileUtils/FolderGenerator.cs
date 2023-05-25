using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace Editor.FileUtils {
    using static AssetDatabase;

    internal static class FolderGenerator {
        const string DefaultFolder = "Assets";
        const string MenuItemPath = "Assets/Create/Folders/";
        const string ToolsMenuPath = "Tools/Setup/Create Base Project";

        const string ScriptsFolder = "Scripts";
        const string PrefabsFolder = "Prefabs";
        const string InterfacesFolder = "Abstractions";
        const string ScriptableFolder = "ScriptableObjects";
        const string BaseProject = "_Project";
        static readonly string[] BaseFolders = { "AppUI", "Core", "Game", "Scenes" };

        [MenuItem(MenuItemPath + ScriptsFolder + PrefabsFolder, priority = 11)]
        public static void CreateDefaultFolders() {
            var path = FindClickedAssetPath();

            CreateFolder(path, ScriptsFolder);
            CreateFolder(path, PrefabsFolder);
        }

        [MenuItem(MenuItemPath + ScriptsFolder + InterfacesFolder, priority = 11)]
        public static void CreateInterfacesFolders() {
            var path = FindClickedAssetPath();

            CreateFolder(path, ScriptsFolder);
            CreateFolder(path, InterfacesFolder);
        }

        [MenuItem(MenuItemPath + ScriptableFolder, priority = 11)]
        public static void CreateScriptableFolders() {
            CreateFolder(FindClickedAssetPath(), ScriptableFolder);
        }

        [MenuItem(MenuItemPath + ScriptsFolder + ScriptableFolder, priority = 11)]
        public static void CreateScriptableScriptsFolders() {
            var path = FindClickedAssetPath();

            CreateFolder(path, ScriptsFolder);
            CreateFolder(path, ScriptableFolder);
        }

        [MenuItem(ToolsMenuPath)]
        public static void CreateDefaultProject() {
            CreateDirectories(BaseProject, BaseFolders);
            Refresh();
        }

        /// <summary>
        /// Finds the point where the mouse clicked in the assets folder
        /// </summary>
        /// <returns></returns>
        static string FindClickedAssetPath() {
            var path = GetAssetPath(Selection.activeObject);

            if (path.Equals(string.Empty))
                path = DefaultFolder;

            if (!Path.GetExtension(path).Equals(string.Empty))
                path = path.Replace(Path.GetFileName(GetAssetPath(Selection.activeObject)), string.Empty);

            return path;
        }

        static void CreateDirectories(string root, params string[] dir) {
            var fullPath = Path.Combine(Application.dataPath, root);
            foreach (var newDirectory in dir)
                Directory.CreateDirectory(Path.Combine(fullPath, newDirectory));
        }
    }
}
#endif
