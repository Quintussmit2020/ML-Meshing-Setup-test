using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class MeshControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshingSubsystemComponent meshingSubsystemComponent;
    private MLPermissions.Callbacks mlPermissionsCallbacks = new MLPermissions.Callbacks(); 
    void Awake()
    {
        meshingSubsystemComponent.enabled = false;
        mlPermissionsCallbacks.OnPermissionGranted += MlPermissionsCallbacks_OnPermissionGranted;
        mlPermissionsCallbacks.OnPermissionDenied += MlPermissionsCallbacks_OnPermissionDenied;
        mlPermissionsCallbacks.OnPermissionDeniedAndDontAskAgain += MlPermissionsCallbacks_OnPermissionDenied;
    }

    void Start()
    {
        MLPermissions.RequestPermission(MLPermission.SpatialMapping, mlPermissionsCallbacks);

    }

    private void MlPermissionsCallbacks_OnPermissionDenied(string permission)
    {
        meshingSubsystemComponent.enabled = false;
    }

    private void MlPermissionsCallbacks_OnPermissionGranted(string permission)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
