using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class SceneLoader: MonoBehaviour
{
    [SerializeField] private string SceneToPlay;
    [SerializeField] private bool PressAnything;
    [SerializeField] private bool ImmediatelyLoad = false;
    
    public Animator transition;
    public float transitionTime = 1.3f;
    public bool FirstAnimation = false;
    public bool LastAnimation = false;


    void Update()
    {

        if ((PressAnything && (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame || Mouse.current.middleButton.wasPressedThisFrame)) || ImmediatelyLoad)
        {
            if (FirstAnimation)
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
            else
            {
                ChangeScene();
            }

            if (LastAnimation)
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");
        // Wait for the animation to finish
        yield return new WaitForSeconds(transitionTime);
        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(SceneToPlay))
        {
            SceneManager.LoadScene(SceneToPlay);
        }
        else
        {
            Debug.LogError("SceneToPlay is not set.");
        }
    }

}
