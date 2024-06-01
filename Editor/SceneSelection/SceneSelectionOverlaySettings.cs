using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor.SceneSelection
{
    using static SceneSelectionConfig;

    [FilePath(SelectionProjectSettingsPath, FilePathAttribute.Location.ProjectFolder)]
    internal sealed class SceneSelectionOverlaySettings : ScriptableSingleton<SceneSelectionOverlaySettings>
    {
        [SerializeField] private bool _additiveOptionEnabled;
        [SerializeField] private bool _notificationsEnabled;

        [SerializeField] private List<SceneAsset> _addedScenes = new();
        
        public IReadOnlyList<SceneAsset> AddedScenes => _addedScenes;
        public IEnumerable<string> AddedScenesPath => AddedScenes.Select(scene => scene.name);

        public bool AdditiveOptionEnabled
        {
            get => _additiveOptionEnabled;
            set
            {
                _additiveOptionEnabled = value;
                Save(true);
            }
        }

        public bool NotificationsEnabled
        {
            get => _notificationsEnabled;
            set
            {
                _notificationsEnabled = value;
                Save(true);
            }
        }

        public void AddScene(SceneAsset scene)
        {
            if (_addedScenes.Contains(scene))
            {
                return;
            }

            _addedScenes.Add(scene);
            EditorUtility.SetDirty(this);
        }

        public void RemoveScene(SceneAsset scene)
        {
            if (_addedScenes.Remove(scene))
            {
                EditorUtility.SetDirty(this);
            }
        }
    }
}