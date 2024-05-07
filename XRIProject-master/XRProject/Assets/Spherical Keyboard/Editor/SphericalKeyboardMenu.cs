using UnityEngine;
using UnityEditor;

public class SphericalKeyboardMenu
{
    private const string path = "GameObject/Alternative Keyboard/";
    private const string create = "Create ";
    private const string sphericalkeyboard = "Spherical Keyboard";

    [MenuItem(path + sphericalkeyboard, false, 1)]
    public static void SphericalKeyboard()
    {
        GameObject go = new GameObject();
        Undo.RegisterCreatedObjectUndo(go, create + sphericalkeyboard );
        go.name = sphericalkeyboard;

        SphericalKeyboard spk = go.AddComponent<SphericalKeyboard>();
        spk.initializeSphericalkeyboard();
    }
}

