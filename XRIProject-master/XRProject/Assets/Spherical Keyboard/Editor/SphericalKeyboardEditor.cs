using UnityEngine;
using UnityEditor;

	
[CustomEditor(typeof(SphericalKeyboard))]
public class SphericalKeyboardEditor : UnityEditor.Editor {

    private SphericalKeyboard spk;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        spk = (SphericalKeyboard) target;

        if( GUI.changed )
        {
            spk.initializeSphericalkeyboard();
        }
    }

}

