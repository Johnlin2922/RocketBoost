using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovementScript : MonoBehaviour {

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private bool controlsEnabled = true;

    [SerializeField] private float boosterForce = 900;
    [SerializeField] private float rotationForce = 400;
    [SerializeField] private AudioClip mainEngineSound;

    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem mainThrustParticles;

    private void Start(){
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update(){
        if (controlsEnabled) {
            ProcessThrust();
            ProcessRotation();
        }
    }

    private void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) {
            Thrust();
        } else {
            audioSource.Stop();
            mainThrustParticles.Stop();
        }
    }

    private void Thrust() {
        rigidBody.AddRelativeForce(Vector3.up * boosterForce * Time.deltaTime);
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngineSound, 1);
        }
        if (!mainThrustParticles.isPlaying) {
            mainThrustParticles.Play();
        }
    }

    private void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            if (!rightThrustParticles.isPlaying) {
                rightThrustParticles.Play();
            }
            applyRotation(rotationForce);
        } else {
            rightThrustParticles.Stop();

        }

        if (Input.GetKey(KeyCode.D)) {
            if (!leftThrustParticles.isPlaying) {
                leftThrustParticles.Play();
            }
            applyRotation(-rotationForce);

        } else {
            leftThrustParticles.Stop();
        }
    }

    private void applyRotation(float rotationThisFrame) {
        rigidBody.freezeRotation = true;
        transform.Rotate(new Vector3(0, 0, 1) * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
        //rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    public void DisableControls() {
        controlsEnabled = false;
    }
}
