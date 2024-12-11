using Mirror;
using UnityEngine;

/// <summary>
/// Handles server-side message reception and processes commands to control AV behavior in various interaction scenarios.
/// </summary>
public class receiveMsg : NetworkBehaviour
{
    private Mymessage currentMsg; // Current message received
    private GameObject AutonomousVehicle; // The AV GameObject
    private AVMoves avMoves; // Reference to the AVMoves script

    private void Start()
    {
        // Register message handler
        NetworkClient.RegisterHandler<Mymessage>(OnMessageReceived);

        // Find the AV GameObject and AVMoves component
        AutonomousVehicle = GameObject.Find("Autonomous Vehicle");
        if (AutonomousVehicle != null)
        {
            avMoves = AutonomousVehicle.GetComponent<AVMoves>();
        }

        if (avMoves == null)
        {
            Debug.LogError("AVMoves component is missing from the Autonomous Vehicle.");
        }
    }

    private void Update()
    {
        if (currentMsg != null && avMoves != null)
        {
            ProcessMessage(currentMsg);
        }
    }

    /// <summary>
    /// Handles incoming messages from clients.
    /// </summary>
    /// <param name="msg">The received message containing AV control commands.</param>
    private void OnMessageReceived(Mymessage msg)
    {
        currentMsg = msg;
    }

    /// <summary>
    /// Processes the received message and triggers the appropriate AV behavior.
    /// </summary>
    /// <param name="msg">The received message containing AV control commands.</param>
    private void ProcessMessage(Mymessage msg)
    {
        if (msg.intValue == 1) // Start driving
        {
            avMoves.StartAVDriving();
        }
        else if (msg.intValue == 2) // Resume driving
        {
            avMoves.ResumeAVDriving();
        }
        else if (msg.intValue == 3) // Stop or Decelerate
        {
            if (avMoves.avType == AVMoves.AVType.Yield)
            {
                avMoves.DecelerateAV();
            }
            else if (avMoves.avType == AVMoves.AVType.NonYield)
            {
                avMoves.StopAV();
            }
        }
        Debug.Log($"Processed message: intValue = {msg.intValue}");
    }
}

/// <summary>
/// Custom network message structure.
/// </summary>
public struct Mymessage : NetworkMessage
{
    public int intValue; // The command for AV behavior (1 = Start, 2 = Resume, 3 = Stop/Decelerate)
}
