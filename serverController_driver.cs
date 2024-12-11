using Mirror;
using UnityEngine;

/// <summary>
/// Manages driver position, rotation, and vehicle-specific data (e.g., wheel rotations) for accurate simulation of manual vehicle dynamics.
/// </summary>
public class serverController_driver: NetworkBehaviour
{
    [Header("Driver and Vehicle Components")]
    [SerializeField] private Transform driverObject;

    private Vector3 driverPosition;
    private Quaternion driverRotation;

    private void Start()
    {
        if (isServer)
        {
            Debug.Log("Server is active.");
        }
    }

    private void Update()
    {
        if (!isServer) return;

        // Update driver position and rotation
        driverPosition = driverObject.position;
        driverRotation = driverObject.rotation;

        // Synchronize data with clients
        RpcUpdateDriverData(driverPosition, driverRotation);
    }

    [ClientRpc]
    private void RpcUpdateDriverData(Vector3 position, Quaternion rotation)
    {
        Debug.Log("Server: Updating driver data on clients.");
    }
}
