using UnityEditor;
using UnityEngine;
using PSEMO.Persistence;

namespace PSEMO.Editor
{
    [CustomEditor(typeof(Persists), true)]
    [CanEditMultipleObjects]
    public class PersistsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Generate New ID", GUILayout.Height(30)))
            {
                foreach (var t in targets)
                {
                    Persists script = (Persists)t;
                    Undo.RecordObject(script, "Generate New ID");
                    script.GenerateId();
                    EditorUtility.SetDirty(script);
                }
            }
        }
    }
}
