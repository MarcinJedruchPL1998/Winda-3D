using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public GameObject elevatorDoor;
    public GameObject callElevator;
    public AudioSource elevator_audio;

    public AudioClip sound_start;
    public AudioClip sound_end;
    
    int chosen_level;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            RaycastHit rayhit;
            
            if(Physics.Raycast(ray, out rayhit))
            {
                string tag = rayhit.collider.tag;
                
                switch(tag)
                {
                    case "elevator_door_btn":
                        ElevatorDoorOpenClose(true);
                        break;

                    case "call_elevator_1":
                        Debug.Log("Wezwano windê na poziom 1!");
                        callElevator.GetComponent<CallElevatorScript>().CallTheElevator(1);
                        break;

                    case "call_elevator_2":
                        Debug.Log("Wezwano windê na poziom 2!");
                        callElevator.GetComponent<CallElevatorScript>().CallTheElevator(2);
                        break;

                    case "call_elevator_3":
                        Debug.Log("Wezwano windê na poziom 3!");
                        callElevator.GetComponent<CallElevatorScript>().CallTheElevator(3);
                        break;

                    case "call_elevator_4":
                        Debug.Log("Wezwano windê na poziom 4!");
                        callElevator.GetComponent<CallElevatorScript>().CallTheElevator(4);
                        break;


                    case "level_1_btn":
                        chosen_level = 1;
                        PlayAnimationClick(rayhit.collider.gameObject);
                        break;

                    case "level_2_btn":
                        chosen_level = 2;
                        PlayAnimationClick(rayhit.collider.gameObject);
                        break;

                    case "level_3_btn":
                        chosen_level = 3;
                        PlayAnimationClick(rayhit.collider.gameObject);
                        break;

                    case "level_4_btn":
                        chosen_level = 4;
                        PlayAnimationClick(rayhit.collider.gameObject);
                        break;

                }

                GetComponent<ElevatorRideScript>().MoveToChosenLevel(chosen_level);
            }
        }

    }

    public void PlayAnimationClick(GameObject rayhitGO)
    {
        Animator animator = rayhitGO.GetComponent<Animator>();
        animator.enabled = true;
        animator.Play("level_btn_click");
        animator.Rebind();

        StartCoroutine(CloseElevatorDoorAfterTime(rayhitGO.GetComponent<BoxCollider>()));
    }

    public void ElevatorDoorOpenClose(bool open)
    {
        Animator anim = elevatorDoor.GetComponent<Animator>();

        if (open)
        {
            anim.enabled = true;
            anim.Play("elevator_door_open");
            elevator_audio.clip = sound_end;
            elevator_audio.Play();
        }
        else
        {
            anim.enabled = true;
            anim.Play("elevator_door_close");
            elevator_audio.clip = sound_start;
            elevator_audio.Play();
        }
    }

    IEnumerator CloseElevatorDoorAfterTime(BoxCollider buttonBC)
    {
        buttonBC.enabled = false;
        yield return new WaitForSeconds(3);
        buttonBC.enabled = true;
        ElevatorDoorOpenClose(false);
    }

}
