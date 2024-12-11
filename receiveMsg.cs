using Mirror;
using UnityEngine;

/// <summary>
/// Server-side script for receiving and processing messages to control the behavior
/// of the Autonomous Vehicle (AV) in the VR Multi-Agent Simulation platform.
/// </summary>
public class receiveMsg: NetworkBehaviour
{
    private Mymessage currentMsg;
    private GameObject AutonomousVehicle;

    private void Start()
    {
        NetworkClient.RegisterHandler<Mymessage>(OnMessageReceived);
        AutonomousVehicle = GameObject.Find("Autonomous Vehicle");
    }

    private void Update()
    {
        if (currentMsg != null && AutonomousVehicle != null)
        {
            ProcessMessage(currentMsg);
        }
    }

    private void OnMessageReceived(Mymessage msg)
    {
        currentMsg = msg;
    }

    private void ProcessMessage(Mymessage msg)
    {
        if (msg.intValue == 1)
        {
            Debug.Log("AV starts driving.");
        } else if (msg.intValue == 2)
        {
            Debug.Log("AV resumes driving.");
        }
    }
}

/// <summary>
/// Custom network message structure.
/// </summary>
public struct Mymessage: NetworkMessage
{
    public int intValue;
}
