using UnityEngine;
using UnityEditor;

public class ObstaclePlacementTool : EditorWindow
{
    [MenuItem("Tools/ObjectPlacementTool")]
    public static void ShowWindow()
    {
        GetWindow<ObstaclePlacementTool>();
    }

    public GameObject LeftMouseButtonObject;
    public EObstacleType ObstacleType;
    public GameObject RightMouseButtonObject;
    public GameObject MiddleMouseButtonObject;

    private SerializedObject so;
    private SerializedProperty LeftMouseButtonObjectProp;
    private SerializedProperty RightMouseButtonObjectProp;
    private SerializedProperty MiddleMouseButtonObjectProp;
    private SerializedProperty ObstacleTypeProp;

    private bool EnablePlacementMode = false;

    private void OnGUI()
    {
        GUILayout.Label("Objects to Place:");

        EditorGUILayout.PropertyField(LeftMouseButtonObjectProp, new GUIContent("Left Mouse Button"), true);
        EditorGUILayout.PropertyField(ObstacleTypeProp, new GUIContent("Obstacle Type"), true);

        EditorGUILayout.PropertyField(RightMouseButtonObjectProp, new GUIContent("Right Mouse Button"), true);
        EditorGUILayout.PropertyField(MiddleMouseButtonObjectProp, new GUIContent("Middle Mouse Button"), true);

        so.ApplyModifiedProperties();

        GUILayout.Space(10);
        EnablePlacementMode = GUILayout.Toggle(EnablePlacementMode, "Enable Placement Mode?");
    }

    private void OnEnable()
    {
        so = new SerializedObject(this);
        LeftMouseButtonObjectProp = so.FindProperty("LeftMouseButtonObject");
        RightMouseButtonObjectProp = so.FindProperty("RightMouseButtonObject");
        MiddleMouseButtonObjectProp = so.FindProperty("MiddleMouseButtonObject");

        ObstacleTypeProp = so.FindProperty("ObstacleType");

        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        if(EnablePlacementMode)
        {
            Event currentEvent = Event.current;

            if(currentEvent.type == EventType.MouseDown)
            {
                Ray r = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);

                Debug.Log(string.Format("Button Pressed: {0}", currentEvent.button));
                Debug.Log(string.Format("Click count: {0}", currentEvent.clickCount));

                Vector3 placementPosition = r.origin;
                placementPosition.z = 0.0f;

                if (currentEvent.button == 0 && currentEvent.clickCount == 1)
                {
                    GameObject go = Instantiate(LeftMouseButtonObject, placementPosition, Quaternion.identity);
                    go.GetComponent<Obstacle>().SetObstacleType(ObstacleType);

                    Selection.SetActiveObjectWithContext(go, this);
                }
                else if (currentEvent.button == 1 && currentEvent.clickCount == 1)
                {
                    Instantiate(RightMouseButtonObject, placementPosition, Quaternion.identity);
                }
                else if (currentEvent.button == 2 && currentEvent.clickCount == 1)
                {
                    Instantiate(MiddleMouseButtonObject, placementPosition, Quaternion.identity);
                }
            }
        }
    }


}
