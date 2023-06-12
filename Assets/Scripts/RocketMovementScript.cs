using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private Rigidbody rigidBody;

    [SerializeField] private float boosterForce = 200;

    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update(){

        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) {
            Debug.Log("Pressed Space, Thrusting Now. ");
            rigidBody.AddRelativeForce(Vector3.up * boosterForce * Time.deltaTime);
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("Pressed A, Thrusting Left. ");
        }


        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Pressed D, Thrusting Right. ");
        }
    }
}
