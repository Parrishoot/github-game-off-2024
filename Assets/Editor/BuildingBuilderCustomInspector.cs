using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BuildingBuilder))] 
public class ColliderCreatorEditor : Editor {
	
    // some declaration missing??
	
    override public void  OnInspectorGUI () {

        BuildingBuilder buildingBuilder = (BuildingBuilder) target;

        DrawDefaultInspector();

        EditorGUILayout.Space(20f);

        if(GUILayout.Button("Update Building Height")) {
	        buildingBuilder.UpdateBuildingHeight();
        }
    }
}