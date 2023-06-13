using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandlerScript : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        string otherTag = collision.gameObject.tag;
        switch (otherTag) {
            case "Friendly":
                Debug.Log("bumped into friendly object, doing nothing");
                break;
            case "Finish":
                Debug.Log("Congrats, you finished level");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Picked Up Fuel");
                break;
            default:
                Debug.Log("Reached defult case");
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence() {

        RocketMovementScript movementScript = GetComponent<RocketMovementScript>();
        movementScript.DisableControls();
        Invoke("ReloadScene", 2f);
    }

    private void StartSuccessSequence() {
        RocketMovementScript movementScript = GetComponent<RocketMovementScript>();
        movementScript.DisableControls();
        Invoke("LoadNextScene", 2f);
    }

    private void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
