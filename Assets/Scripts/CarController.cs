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

    [Header("General properties")]
    [Tooltip("Type of vehicle. Hover vehicles can only make use of raycast based suspension.")]
    public VehicleType vehicleType = VehicleType.GroundVehicle;
    [Tooltip("Type of suspension to use.")]
    public SuspensionType suspensionType = SuspensionType.Raycasts;
    [Tooltip("Center of Mass position.")]
    public Transform centerOfMass;

    public DriveType driveType { get; set; }


    private void OnValidate()
    {
        if (vehicleType == VehicleType.HoverVehicle)
        {
            suspensionType = SuspensionType.Raycasts;
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(CarController))]
public class CarControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var myScript = target as CarController;

        if (myScript.vehicleType == VehicleType.GroundVehicle)
        {
            myScript.driveType = (DriveType)EditorGUILayout.EnumPopup("Drive Type", myScript.driveType);
        }
    }
}
#endif

