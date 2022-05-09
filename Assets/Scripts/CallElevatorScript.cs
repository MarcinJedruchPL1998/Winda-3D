using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevatorScript : MonoBehaviour
{
    public GameObject elevator;

   
    public void CallTheElevator(int call_level)
    {
        elevator.GetComponent<ElevatorRideScript>().isMoving = true;
        elevator.GetComponent<ElevatorRideScript>().chosen_level = call_level;
        elevator.GetComponent<ElevatorScript>().ElevatorDoorOpenClose(false);
    }
}
