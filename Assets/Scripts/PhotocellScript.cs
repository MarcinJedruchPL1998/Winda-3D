using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotocellScript : MonoBehaviour
{
    public ElevatorScript elevatorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //elevatorScript.ElevatorDoorOpenClose(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //elevatorScript.ElevatorDoorOpenClose(false);
        }
    }
}
