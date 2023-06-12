using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private Rigidbody rigidBody;

    [SerializeField] private float boosterForce = 900;
    [SerializeField] private float rotationForce = 400;

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
            transform.Rotate(new Vector3(0, 0, 1) * rotationForce * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Pressed D, Thrusting Right. ");
            transform.Rotate(new Vector3(0, 0, -1) * rotationForce * Time.deltaTime);
        }
    }
}
