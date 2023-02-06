using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
namespace Editor.SceneSelection {
    using UnityEditor;
    using UnityEditor.Overlays;
    using UnityEditor.SceneManagement;
    using UnityEditor.Toolbars;

    [Overlay(typeof(SceneView), "Scene Selection")]
    [Icon(Icon)]
    internal sealed class SceneSelectionOverlay : ToolbarOverlay {
        const string Icon = "Assets/Editor/Icons/UnityIcon.png";
        const string AllScenes = "All Scenes";
        const string BuildScenes = "Build Scenes";
        const string SceneSearchFilter = "t:scene";
        const string Additive = "/Additive";
        const string Single = "/Single";
        const string Scenes = "Scenes";
        const string ToolTip = "Select a scene to load";

        SceneSelectionOverlay() : base(SceneDropdownToggle.ID) { }

        [EditorToolbarElement(ID, typeof(SceneView))]
        class SceneDropdownToggle : EditorToolbarDropdownToggle, IAccessContainerWindow {
            public const string ID = "SceneSelectionOverlay/SceneDropdownToggle";
            public EditorWindow containerWindow { get; set; }
            bool _isBuildScenes;

            SceneDropdownToggle() {
                text = Scenes;
                tooltip = ToolTip;
                icon = AssetDatabase.LoadAssetAtPath<Texture2D>(Icon);

                dropdownClicked += InitializeSceneMenu;
            }

            void InitializeSceneMenu() {
                var menu = new GenericMenu();

                var buttonName = _isBuildScenes ? AllScenes : BuildScenes;
                menu.AddItem(new GUIContent(buttonName), true, () => _isBuildScenes = !_isBuildScenes);
                menu.AddSeparator(string.Empty);
                if (_isBuildScenes) {
                    CreateBuildScenes(menu);
                    return;
                }

                CreateAllScenes(menu);
            }

            void CreateBuildScenes(GenericMenu menu) {
                var activeScene = SceneManager.GetActiveScene();

                var buildScenes = EditorBuildSettings.scenes;

                CreateScenes(menu, buildScenes.Select(scene => scene.path), activeScene);
            }

            void CreateAllScenes(GenericMenu menu) {
                var activeScene = SceneManager.GetActiveScene();

                var sceneGuids = AssetDatabase.FindAssets(SceneSearchFilter, null);

                CreateScenes(menu, sceneGuids, activeScene);
            }

            void CreateScenes(GenericMenu menu, IEnumerable<string> sceneGuids, Scene activeScene) {
                foreach (var scene in sceneGuids) {
                    var path = AssetDatabase.GUIDToAssetPath(scene);
                    var sceneName = Path.GetFileNameWithoutExtension(path);

                    if (string.CompareOrdinal(activeScene.name, sceneName) == 0) {
                        menu.AddDisabledItem(new GUIContent(sceneName));
                        continue;
                    }

                    if (SceneSelectionOverlaySettings.instance.AdditiveOptionEnabled) {
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

            void OpenScene(Scene activeScene, string path, OpenSceneMode mode) {
                if (activeScene.isDirty) {
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