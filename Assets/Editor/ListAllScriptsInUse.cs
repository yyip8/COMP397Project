using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ListAllScriptsInUse : EditorWindow
{
    [MenuItem("Tools/List All Scripts In Use")]
    public static void ShowWindow()
    {
        GetWindow<ListAllScriptsInUse>("List All Scripts In Use");
    }

    private Vector2 scrollPosition;

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        var allPrefabs = AssetDatabase.FindAssets("t:Prefab")
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
            .Select(path => AssetDatabase.LoadAssetAtPath<GameObject>(path))
            .ToList();

        var scriptInfo = new Dictionary<string, List<(string objectName, string scriptPath)>>();

        // Get scripts from prefabs
        foreach (var prefab in allPrefabs)
        {
            var components = prefab.GetComponentsInChildren<MonoBehaviour>(true);

            foreach (var component in components)
            {
                if (component != null)
                {
                    string scriptName = component.GetType().ToString();
                    string scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(component));
                    if (!scriptInfo.ContainsKey(scriptName))
                    {
                        scriptInfo[scriptName] = new List<(string objectName, string scriptPath)>();
                    }

                    scriptInfo[scriptName].Add((prefab.name, scriptPath));
                }
            }
        }

        // Get scripts from objects in the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] allObjects = currentScene.GetRootGameObjects();
        foreach (var gameObject in allObjects)
        {
            var components = gameObject.GetComponentsInChildren<MonoBehaviour>(true);

            foreach (var component in components)
            {
                if (component != null)
                {
                    string scriptName = component.GetType().ToString();
                    string scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(component));
                    if (!scriptInfo.ContainsKey(scriptName))
                    {
                        scriptInfo[scriptName] = new List<(string objectName, string scriptPath)>();
                    }

                    scriptInfo[scriptName].Add((gameObject.name, scriptPath));
                }
            }
        }

        foreach (string scriptName in scriptInfo.Keys.OrderBy(name => name))
        {
            EditorGUILayout.LabelField("Script: " + scriptName);
            EditorGUILayout.BeginVertical("box");
            foreach (var (objectName, scriptPath) in scriptInfo[scriptName].Distinct().OrderBy(info => info.objectName))
            {
                EditorGUILayout.LabelField(" - " + objectName + " (" + scriptPath + ")");
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }
}
