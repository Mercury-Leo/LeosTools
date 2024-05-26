using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor.SceneSelection
{
    using static SceneSelectionConfig;

    internal sealed class SceneSelectionOverlaySettingsProvider : SettingsProvider
    {
        private SceneSelectionOverlaySettingsProvider(string path, SettingsScope scopes,
            IEnumerable<string> keywords = null) : base(path, scopes, keywords) { }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);

            GUILayout.Space(20f);

            var enabled = SceneSelectionOverlaySettings.instance.AdditiveOptionEnabled;
            var value = EditorGUILayout.Toggle(AdditiveOption, enabled, GUILayout.Width(200f));

            if (enabled != value)
                SceneSelectionOverlaySettings.instance.AdditiveOptionEnabled = value;
        }

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new SceneSelectionOverlaySettingsProvider(SelectionOverlayPath, SettingsScope.Project);
        }
    }
}