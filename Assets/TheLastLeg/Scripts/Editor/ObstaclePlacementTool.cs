using System;
using UnityEngine;
using UnityEditor;


public enum EMouseButton
{
    Left,
    Right,
    Middle
}

[System.Serializable]
public class Placer
{
    public GameObject objectToPlace;
    public EObstacleType ObstacleType;
    public Transform ParentTranform;
    public EMouseButton MouseButton;
    public bool Alt;
    public bool Ctrl;
    public bool Shift;
}

public class ObstaclePlacementTool : EditorWindow
{
    [MenuItem("Tools/Placer")]
    public static void ShowWindow()
    {
        GetWindow<ObstaclePlacementTool>("Placer");
    }

    public Placer[] placers;

    private SerializedObject so;
    private SerializedProperty PlacersProp;

    private bool EnablePlacementMode = false;
    private Vector2 scrollPosition;

    private void OnGUI()
    {
        EnablePlacementMode = GUILayout.Toggle(EnablePlacementMode, "Enable Placement Mode?");
        GUILayout.Label("Objects to Place:");
        
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        EditorGUILayout.PropertyField(PlacersProp, true);
        GUILayout.EndScrollView();
        so.ApplyModifiedProperties();
    }

    private void OnEnable()
    {
        so = new SerializedObject(this);
        PlacersProp = so.FindProperty("placers");

        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        if(EnablePlacementMode)
        {
            Event currentEvent = Event.current;

            if(currentEvent.type == EventType.MouseDown)
            {
                Placer placer = Array.Find(placers, p => p.MouseButton == (EMouseButton)currentEvent.button && p.Alt == currentEvent.alt 
                && p.Ctrl == currentEvent.control && p.Shift == currentEvent.shift);

                if(placer != null)
                {
                    Ray ray = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);
                    Vector3 placementPosition = ray.origin;
                    placementPosition.z = 0.0f;

                    GameObject gameObject = Instantiate(placer.objectToPlace, placementPosition, Quaternion.identity, placer.ParentTranform);
                    Obstacle obstacle = gameObject.GetComponent<Obstacle>();
                    if(obstacle != null)
                    {
                        obstacle.SetObstacleType(placer.ObstacleType);
                    }

                    currentEvent.Use();
                }
            }
        }
    }


}
