using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Tools.Editor.SceneSelection
{
    public static class SceneExtensions
    {
        private const string SceneSearchFilter = "t:Scene";

        [Pure]
        public static IEnumerable<string> GetAllScenesPath()
        {
            return AssetDatabase.FindAssets(SceneSearchFilter).Select(AssetDatabase.GUIDToAssetPath);
        }

        [Pure]
        public static IEnumerable<string> GetAllBuildScenesPath()
        {
            return EditorBuildSettings.scenes.Select(scene => scene.path);
        }

        [Pure]
        public static IEnumerable<string> GetAllScenesPathWithoutBuildScenes()
        {
            return GetAllScenesPath().Except(GetAllBuildScenesPath());
        }

#if UNITY_EDITOR
        [Pure]
        public static IEnumerable<SceneAsset> GetAllSceneAssets()
        {
            return GetAllScenesPath().Select(AssetDatabase.LoadAssetAtPath<SceneAsset>);
        }

        [Pure]
        public static IEnumerable<SceneAsset> GetAllSceneAssetsWithoutBuildScenes()
        {
            return GetAllScenesPathWithoutBuildScenes().Select(AssetDatabase.LoadAssetAtPath<SceneAsset>);
        }
#endif
    }
}