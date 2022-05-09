using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorRideScript : MonoBehaviour
{
    public Transform[] levels;
    public float moveSpeed;
    public TextMeshPro lvl_number;

    public bool isMoving;
    public int chosen_level;
    int current_level;

    public void MoveToChosenLevel(int level)
    {
        if (level != current_level)
        {
            chosen_level = level;
            isMoving = true;
            GetComponent<ElevatorScript>().ElevatorDoorOpenClose(false);
        }
    }

    void Update()
    {
        if (isMoving && chosen_level != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, levels[chosen_level - 1].position, moveSpeed * Time.deltaTime);

            if(current_level == chosen_level)
            {
                StartCoroutine(OpenElevatorDoor());
            }
        }

    }

    IEnumerator OpenElevatorDoor()
    {
        isMoving = false;
        yield return new WaitForSeconds(1);
        GetComponent<ElevatorScript>().ElevatorDoorOpenClose(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "level_1")
        {
            current_level = 1;
        }
        if (other.gameObject.tag == "level_2")
        {
            current_level = 2;
        }
        if (other.gameObject.tag == "level_3")
        {
            current_level = 3;
        }
        if (other.gameObject.tag == "level_4")
        {
            current_level = 4;
        }

        lvl_number.text = current_level.ToString();
    }
}
