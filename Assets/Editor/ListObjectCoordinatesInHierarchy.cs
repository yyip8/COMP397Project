using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class ListObjectCoordinatesInHierarchy : EditorWindow
{
    [MenuItem("Tools/List Object Coordinates In Hierarchy")]
    public static void ShowWindow()
    {
        GetWindow<ListObjectCoordinatesInHierarchy>("List Object Coordinates In Hierarchy");
    }

    private Vector2 scrollPosition;

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] allObjects = currentScene.GetRootGameObjects();

        var objectCoordinates = new Dictionary<string, Vector3>();

        Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

        // Get coordinates of all objects in the current scene
        foreach (var gameObject in allObjects)
        {
            var transforms = gameObject.GetComponentsInChildren<Transform>(true);

            foreach (var transform in transforms)
            {
                string objectName = transform.gameObject.name;
                Vector3 position = transform.position;
                objectCoordinates[objectName] = position;

                // Update minimum and maximum coordinates
                min = Vector3.Min(min, position);
                max = Vector3.Max(max, position);
            }
        }

        EditorGUILayout.LabelField("Minimum Coordinates: " + min, EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Maximum Coordinates: " + max, EditorStyles.boldLabel);
        EditorGUILayout.Space();

        foreach (string objectName in objectCoordinates.Keys.OrderBy(name => name))
        {
            EditorGUILayout.LabelField("Object: " + objectName);
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField(" - Position: " + objectCoordinates[objectName]);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }
}
