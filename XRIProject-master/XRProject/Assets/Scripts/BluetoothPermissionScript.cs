
using UnityEngine.Android;
using UnityEngine;
using System;

public class BluetoothPermissionScript : MonoBehaviour
{

    // Check if we have Bluetooth permission
    void Start()
    {
        try
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                // Ask for Bluetooth permission
                Permission.RequestUserPermission(Permission.FineLocation);
            }
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError("Error occurred while requesting Bluetooth permission: " + ex.Message);
        }
    }
}
