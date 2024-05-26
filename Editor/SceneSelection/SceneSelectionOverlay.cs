using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.SceneManagement;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
namespace Tools.Editor.SceneSelection
{
    [Overlay(typeof(SceneView), "Scene Selection")]
    [Icon(Icon)]
    internal sealed class SceneSelectionOverlay : ToolbarOverlay
    {
        private const string Icon = "Assets/Editor/Icons/UnityIcon.png";
        private const string AllScenes = "All Scenes";
        private const string BuildScenes = "Build Scenes";
        private const string SceneSearchFilter = "t:scene";
        private const string Additive = "/Additive";
        private const string Single = "/Single";
        private const string Scenes = "Scenes";
        private const string ToolTip = "Select a scene to load";

        private SceneSelectionOverlay() : base(SceneDropdownToggle.ID) { }

        [EditorToolbarElement(ID, typeof(SceneView))]
        private class SceneDropdownToggle : EditorToolbarDropdownToggle, IAccessContainerWindow
        {
            public const string ID = "SceneSelectionOverlay/SceneDropdownToggle";
            public EditorWindow containerWindow { get; set; }
            private bool _isBuildScenes;

            private SceneDropdownToggle()
            {
                text = Scenes;
                tooltip = ToolTip;
                icon = AssetDatabase.LoadAssetAtPath<Texture2D>(Icon);

                dropdownClicked += InitializeSceneMenu;
            }

            private void InitializeSceneMenu()
            {
                var menu = new GenericMenu();

                var buttonName = _isBuildScenes ? AllScenes : BuildScenes;
                menu.AddItem(new GUIContent(buttonName), true, () => _isBuildScenes = !_isBuildScenes);
                menu.AddSeparator(string.Empty);
                if (_isBuildScenes)
                {
                    CreateBuildScenes(menu);
                    return;
                }

                CreateAllScenes(menu);
            }

            private void CreateBuildScenes(GenericMenu menu)
            {
                var activeScene = SceneManager.GetActiveScene();

                var buildScenes = EditorBuildSettings.scenes;

                CreateScenes(menu, buildScenes.Select(scene => scene.path), activeScene);
            }

            private void CreateAllScenes(GenericMenu menu)
            {
                var activeScene = SceneManager.GetActiveScene();

                var sceneGuids = AssetDatabase.FindAssets(SceneSearchFilter, null);

                CreateScenes(menu, sceneGuids, activeScene);
            }

            private void CreateScenes(GenericMenu menu, IEnumerable<string> sceneGuids, Scene activeScene)
            {
                foreach (var scene in sceneGuids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(scene);
                    var sceneName = Path.GetFileNameWithoutExtension(path);

                    if (string.CompareOrdinal(activeScene.name, sceneName) == 0)
                    {
                        menu.AddDisabledItem(new GUIContent(sceneName));
                        continue;
                    }

                    if (SceneSelectionOverlaySettings.instance.AdditiveOptionEnabled)
                    {
                        menu.AddItem(new GUIContent(sceneName + Single), false,
                            () => OpenScene(activeScene, path, OpenSceneMode.Single));
                        menu.AddItem(new GUIContent(sceneName + Additive), false,
                            () => OpenScene(activeScene, path, OpenSceneMode.Additive));
                        return;
                    }

                    menu.AddItem(new GUIContent(sceneName), false,
                        () => OpenScene(activeScene, path, OpenSceneMode.Single));
                }

                menu.ShowAsContext();
            }

            private void OpenScene(Scene activeScene, string path, OpenSceneMode mode)
            {
                if (activeScene.isDirty)
                {
                    if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                        EditorSceneManager.OpenScene(path, mode);
                    return;
                }

                EditorSceneManager.OpenScene(path, mode);
            }
        }
    }
}
#endif