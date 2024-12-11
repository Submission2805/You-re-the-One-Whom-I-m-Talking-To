using Mirror;
using UnityEngine;

/// <summary>
/// Synchronizes cyclist position and rotation data and updates it for connected clients in the simulation.
/// </summary>
public class serverController_cyclist: NetworkBehaviour
{
    [Header("Cyclist and Body Parts")]
    [SerializeField] private Transform cyclistObject;
    [SerializeField] private Transform Cyclist;

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

        // Gather position and rotation data
        Vector3 cyclistPosition = cyclistObject.position;
        Quaternion cyclistRotation = cyclistObject.rotation;

        Vector3 humanPosition = Cyclist.position;
        Quaternion humanRotation = Cyclist.rotation;

        // Synchronize with clients
        RpcUpdateCyclistPosAndRot(cyclistPosition, cyclistRotation, humanPosition, humanRotation);
    }

    [ClientRpc]
    public void RpcUpdateCyclistPosAndRot(Vector3 position, Quaternion rotation, Vector3 hPosition, Quaternion hRotation)
    {
        Debug.Log("Server: Updated cyclist data on client.");
    }
}
