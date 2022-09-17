using System;
using UnityEngine;

public class ElevatorCommunicator
{
    public delegate void ElevatorReachingTargetFloor();
    public ElevatorReachingTargetFloor OnElevatorReachingTargetFloor;

    public ElevatorState ElevatorState { get; set; } = ElevatorState.Waiting;
    public int CurrentFloor { get; set; } = 0;
    public float CurrentTravelTime { get; set; } = 0.0f;

    float travelDuration = 0.0f;
    float travelTimePerFloor = 2f;

    public void StartElevatorRide(int targetFloor)
    {
        CurrentTravelTime = travelTimePerFloor * Math.Abs(targetFloor - CurrentFloor);
        CurrentFloor = targetFloor;
        travelDuration = 0.0f;
        ElevatorState = ElevatorState.Running;
        LogElevatorState();
    }

    public void Update()
    {
        travelDuration += Time.deltaTime;
        if (travelDuration > CurrentTravelTime)
        {
            CurrentTravelTime = 0.0f;
            travelDuration = 0.0f;
            ElevatorState = ElevatorState.Waiting;
            OnElevatorReachingTargetFloor?.Invoke();
            LogElevatorState();
        }
    }

    void LogElevatorState()
    {
        Debug.Log($"ElevatorState: {ElevatorState}");
        if (ElevatorState == ElevatorState.Running)
        {
            Debug.Log($"Travel time: {CurrentTravelTime}");
        }
    }
}