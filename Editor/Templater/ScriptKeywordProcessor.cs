using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace Editor.Templater {
    internal sealed class ScriptKeywordProcessor : AssetModificationProcessor {
        static readonly char[] Splitters = { '/', '\\', '.' };
        static readonly List<string> WordsToDelete = new List<string>() { "Extensions", "Scripts", "Editor" };
        const string NameSpace = "#NAMESPACE#";
        const string FileExtensions = ".cs";
        const string Assets = "Assets";
        const string Dot = ".";
        const string Meta = ".meta";
        const string DefaultNameSpace = "Globals";

        public static void OnWillCreateAsset(string path) {
            path = path.Replace(Meta, string.Empty);
            var index = path.LastIndexOf(Dot, StringComparison.Ordinal);
            if (index < 0)
                return;

            var file = path[index..];
            if (file != FileExtensions)
                return;

            var namespaces = path.Split(Splitters).ToList();
            namespaces = namespaces.GetRange(1, namespaces.Count - 3);
            namespaces = namespaces.Except(WordsToDelete).ToList();

            var namespaceString = DefaultNameSpace;
            for (var i = 0; i < namespaces.Count; i++) {
                if (i == 0)
                    namespaceString = string.Empty;
                namespaceString += namespaces[i];
                if (i < namespaces.Count - 1)
                    namespaceString += Dot;
            }

            index = Application.dataPath.LastIndexOf(Assets, StringComparison.Ordinal);
            path = Application.dataPath[..index] + path;
            if (!System.IO.File.Exists(path))
                return;

            var fileContent = System.IO.File.ReadAllText(path);
            fileContent = fileContent.Replace(NameSpace, namespaceString);
            System.IO.File.WriteAllText(path, fileContent);
            AssetDatabase.Refresh();
        }
    }
}
#endif