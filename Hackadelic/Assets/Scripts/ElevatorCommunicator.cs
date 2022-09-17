using UnityEngine;

public class ElevatorCommunicator
{
    public static ElevatorState ElevatorState = ElevatorState.Waiting;

    public void StartElevatorRide()
    {
        ElevatorState = ElevatorState.Running;
        LogElevatorState();
    }

    public void StopElevatorRide()
    {
        ElevatorState = ElevatorState.Waiting;
        LogElevatorState();
    }

    void LogElevatorState()
    {
        Debug.Log($"ElevatorState: {ElevatorState}");
    }
}