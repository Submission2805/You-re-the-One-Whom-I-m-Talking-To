using Mirror;
using UnityEngine;

/// <summary>
/// Synchronizes pedestrian movement data and handles eHMI interactions.
/// </summary>
public class PedestrianController: NetworkBehaviour
{
    [Header("Pedestrian Components")]
    [SerializeField] private Transform pedestrianObject;
    [SerializeField] private Transform[] bodyParts;
    public GameObject eHMI;

    private NetworkIdentity objectIdentity;
    private Vector3[] bodyPartPositions;
    private Quaternion[] bodyPartRotations;

    private void Start()
    {
        objectIdentity = pedestrianObject.GetComponent<NetworkIdentity>();
        if (objectIdentity == null)
        {
            objectIdentity = pedestrianObject.gameObject.AddComponent<NetworkIdentity>();
        }

        bodyPartPositions = new Vector3[bodyParts.Length];
        bodyPartRotations = new Quaternion[bodyParts.Length];
    }

    private void Update()
    {
        if (objectIdentity == null) return;

        // Update pedestrian and body part positions and rotations
        UpdateBodyPartData();

        // Send updates to clients
        RpcUpdateBodyParts(bodyPartPositions, bodyPartRotations);

        // Handle eHMI state changes
        if (isServer && Input.GetKeyUp(KeyCode.Space))
        {
            eHMI.SetActive(false);
        }
    }

    private void UpdateBodyPartData()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyPartPositions[i] = bodyParts[i].position;
            bodyPartRotations[i] = bodyParts[i].rotation;
        }
    }

    [ClientRpc]
    private void RpcUpdateBodyParts(Vector3[] positions, Quaternion[] rotations)
    {
        Debug.Log("Client: Updated pedestrian body part positions and rotations.");
    }
}
