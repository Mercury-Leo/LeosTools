using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Editor.SceneSelection {
    using static SceneSelectionConfig;
    [FilePath(SelectionProjectSettingsPath, FilePathAttribute.Location.ProjectFolder)]
    internal sealed class SceneSelectionOverlaySettings : ScriptableSingleton<SceneSelectionOverlaySettings> {
        [SerializeField] bool _additiveOptionEnabled;

        public bool AdditiveOptionEnabled {
            get => _additiveOptionEnabled;
            set {
                _additiveOptionEnabled = value;
                Save(true);
            }
        }
    }
}
#endif