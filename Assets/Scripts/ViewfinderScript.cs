using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewfinderScript : MonoBehaviour
{
    public Text viewfinderText;

    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit rayhit;

        if(Physics.Raycast(ray, out rayhit))
        {
            if (rayhit.collider.tag == "elevator_door_btn")
            {
                Animator anim = GetComponent<Animator>();
                anim.enabled = true;
                anim.Play("viewfinder_open");
                viewfinderText.text = "Otw�rz drzwi windy";
            }

            for(int i = 0; i < 4; i++)
            {
                if (rayhit.collider.tag == "call_elevator_" + i)
                {
                    Animator anim = GetComponent<Animator>();
                    anim.enabled = true;
                    anim.Play("viewfinder_open");
                    viewfinderText.text = "Wezwij wind�";
                }
            }

            if (rayhit.collider.tag == "level_1_btn")
            {
                Animator anim = GetComponent<Animator>();
                anim.enabled = true;
                anim.Play("viewfinder_open");
                viewfinderText.text = "Jed� na 1 pi�tro";
            }

            if (rayhit.collider.tag == "level_2_btn")
            {
                Animator anim = GetComponent<Animator>();
                anim.enabled = true;
                anim.Play("viewfinder_open");
                viewfinderText.text = "Jed� na 2 pi�tro";
            }

            if (rayhit.collider.tag == "level_3_btn")
            {
                Animator anim = GetComponent<Animator>();
                anim.enabled = true;
                anim.Play("viewfinder_open");
                viewfinderText.text = "Jed� na 3 pi�tro";
            }

            if (rayhit.collider.tag == "level_4_btn")
            {
                Animator anim = GetComponent<Animator>();
                anim.enabled = true;
                anim.Play("viewfinder_open");
                viewfinderText.text = "Jed� na 4 pi�tro";
            }

            if (rayhit.collider.tag == "Untagged")
            {
                Animator anim = GetComponent<Animator>();
                anim.Play("viewfinder_close");
               
            }

        }
    }
}
