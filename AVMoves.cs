using UnityEngine;

/// <summary>
/// Unified Autonomous Vehicle (AV) control script for managing different AV behaviors
/// (yielding, mixed, and non-yielding) in the VR Multi-Agent Simulation platform.
/// </summary>
public class AVMoves: MonoBehaviour
{
    public enum AVType { Yield, Mixed, NonYield }
    public AVType avType;

    public GameObject eHMI;

    private bool isAVDriving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAVDriving();
        }

        if (isAVDriving)
        {
            DriveAV();
        }
    }

    public void StartAVDriving()
    {
        isAVDriving = true;
        Debug.Log("AV starts driving.");
    }

    public void DriveAV()
    {
        transform.Translate(Vector3.forward * 10f * Time.deltaTime);
    }
}
