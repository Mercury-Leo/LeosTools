using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Tools.Editor.SceneSelection
{
    using static SceneSelectionConfig;

    [FilePath(SelectionProjectSettingsPath, FilePathAttribute.Location.ProjectFolder)]
    internal sealed class SceneSelectionOverlaySettings : ScriptableSingleton<SceneSelectionOverlaySettings>
    {
        [SerializeField] private bool _additiveOptionEnabled;

        public bool AdditiveOptionEnabled
        {
            get => _additiveOptionEnabled;
            set
            {
                _additiveOptionEnabled = value;
                Save(true);
            }
        }
    }
}
#endif