using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{


    void Start(){
        
    }

    void Update(){

        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Pressed Space, Thrusting Now. ");
        }
    }

    void ProcessRotation() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Pressed A, Thrusting Left. ");
        }


        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("Pressed D, Thrusting Right. ");
        }
    }
}
