using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor // Editor instead of Monobehavior because it is going to be used in the editor, not in game.
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}
