using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandlerScript : MonoBehaviour {

    private AudioSource audioSource;

    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip explosionSound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        string otherTag = collision.gameObject.tag;
        switch (otherTag) {
            case "Friendly":
                Debug.Log("bumped into friendly object, doing nothing");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Picked Up Fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    [ContextMenu("Start Crash Sequence")]
    private void StartCrashSequence() {
        Debug.Log("Starting Crash Sequence, playing clip");
        audioSource.PlayOneShot(explosionSound);
        RocketMovementScript movementScript = GetComponent<RocketMovementScript>();
        movementScript.DisableControls();
        Invoke("ReloadScene", 2f);
    }

    private void StartSuccessSequence() {
        Debug.Log("Congrats, you finished level");
        audioSource.PlayOneShot(successSound);
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
