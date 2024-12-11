using UnityEngine;

/// <summary>
/// Controls AV behaviors, including yielding, mixed, and non-yielding modes, with collision handling
/// </summary>
public class AVMoves : MonoBehaviour
{
    public enum AVType { Yield, NonYield }
    public AVType avType;

    public GameObject eHMI;
    public GameObject stopLine; // Stop line for yielding behavior

    private bool isAVDriving = false;
    private bool isDecelerating = false;
    private bool isStopped = false;

    public float drivingSpeed = 10f; // Default driving speed (m/s)
    public float decelerationRate = 5f; // Deceleration rate (m/s²)
    private float currentSpeed = 0f;
    private Vector3 currentVelocity = Vector3.zero;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAVDriving();
        }

        if (isAVDriving)
        {
            if (avType == AVType.Yield)
            {
                HandleYieldBehavior();
            }
            else if (avType == AVType.NonYield)
            {
                DriveAV();
            }
        }
    }

    /// <summary>
    /// Starts AV driving.
    /// </summary>
    public void StartAVDriving()
    {
        isAVDriving = true;
        isStopped = false;
        currentSpeed = drivingSpeed;
        ResetEHMI();
        Debug.Log("AV starts driving.");
    }

    /// <summary>
    /// Resumes AV driving after a stop or deceleration.
    /// </summary>
    public void ResumeAVDriving()
    {
        if (isStopped || isDecelerating)
        {
            isStopped = false;
            isDecelerating = false;
            currentSpeed = drivingSpeed;
            ResetEHMI();
            Debug.Log("AV resumes driving.");
        }
    }

    /// <summary>
    /// Drives the AV forward at the current speed.
    /// </summary>
    public void DriveAV()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        Debug.Log($"AV is driving at {currentSpeed} m/s.");
    }

    /// <summary>
    /// Stops the AV at the designated stop line.
    /// </summary>
    public void StopAV()
    {
        if (!isStopped && stopLine != null)
        {
            isStopped = true;
            Vector3 targetPosition = stopLine.transform.position;
            float smoothTime = 0.5f;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
            Debug.Log("AV has stopped at the stop line.");
        }
    }

    /// <summary>
    /// Handles yield behavior by decelerating or stopping the AV.
    /// </summary>
    private void HandleYieldBehavior()
    {
        if (isDecelerating)
        {
            DecelerateAV();
        }
        else if (!isStopped && stopLine != null)
        {
            StopAV();
        }
        else
        {
            DriveAV();
        }
    }

    /// <summary>
    /// Decelerates the AV smoothly to stop.
    /// </summary>
    public void DecelerateAV()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= decelerationRate * Time.deltaTime;
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                StopAV();
            }
            Debug.Log($"AV is decelerating. Current speed: {currentSpeed} m/s.");
        }
    }

    /// <summary>
    /// Activates eHMI signaling.
    /// </summary>
    private void ActivateEHMI()
    {
        if (eHMI != null)
        {
            eHMI.SetActive(true);
            Debug.Log("eHMI is activated.");
        }
    }

    /// <summary>
    /// Resets eHMI signaling to inactive state.
    /// </summary>
    private void ResetEHMI()
    {
        if (eHMI != null)
        {
            eHMI.SetActive(false);
            Debug.Log("eHMI is reset.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollisionDetector"))
        {
            isDecelerating = true;
            ActivateEHMI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollisionDetector"))
        {
            isDecelerating = false;
            ResetEHMI();
        }
    }
}
