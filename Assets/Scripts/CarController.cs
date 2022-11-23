using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CarController : MonoBehaviour
{
    [Tooltip("Auto assigns the car stats based on existing presets.")]
    public CarTypePreset carPreset = CarTypePreset.Custom;

    [Header("Car Settings & References")]
    [Tooltip("Type of vehicle. Hover vehicles can only make use of raycast based suspension.")]
    public VehicleType vehicleType = VehicleType.GroundVehicle;
    [Tooltip("Type of suspension to use.")]
    public SuspensionType suspensionType = SuspensionType.Raycasts;
    [Tooltip("Center of Mass position.")]
    public Transform centerOfMass;


    private void OnValidate()
    {
        if (vehicleType == VehicleType.HoverVehicle)
        {
            suspensionType = SuspensionType.Raycasts;
        }
    }
}

/*
#if UNITY_EDITOR
[CustomEditor(typeof(CarController))]
public class CarControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var myScript = target as DeformablePart;

        if (myScript.isHinge)
        {
            GUILayout.Label("Hinge Properties:", EditorStyles.boldLabel);
            myScript.health = EditorGUILayout.FloatField("Health", myScript.health);
            myScript.hingeCreationThreshold = EditorGUILayout.FloatField("Hinge Creation Threshold", myScript.hingeCreationThreshold);
            myScript.hingeAnchor = EditorGUILayout.Vector3Field("Anchor", myScript.hingeAnchor);
            myScript.hingeAxis = EditorGUILayout.Vector3Field("Axis", myScript.hingeAxis);
            myScript.hingeMinLimit = EditorGUILayout.FloatField("Min Limit", myScript.hingeMinLimit);
            myScript.hingeMaxLimit = EditorGUILayout.FloatField("Max Limit", myScript.hingeMaxLimit);
        }
    }
}
#endif
*/
