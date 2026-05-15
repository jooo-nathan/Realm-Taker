using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Threading;

public class SceneLoader : MonoBehaviour
{
    // THREE WAYS TO ANIMATE SCENE

    // 1. PRESS ANYTHING
    // 2. PRESS A SPECIFIC BUTTON
    // 3. AUTOMATICALLY

    [SerializeField] private string SceneToPlay;
    [SerializeField] private bool PressAnything = false;
    [SerializeField] private bool PressAButton = false;
    [SerializeField] private bool ImmediatelyLoad = false;
    [SerializeField] private KeyCode KeyToPress;

    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 0;
    [SerializeField] private bool WithAnimation = false;

    private float timer = 0;
    private float cooldown = 1f;


    void Awake()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= cooldown) return;

        if (ImmediatelyLoad)
        {
            ChangeScene();
        }
        else if (PressAButton)
        {
            if (Input.GetKeyDown(KeyToPress))
            {
                ChangeScene();
            }
        }
        else if (PressAnything)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame || Mouse.current.middleButton.wasPressedThisFrame)
            {
                ChangeScene();
            }
        }
    }

    IEnumerator ChangeSceneWithAnimation()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneToPlay);
    }

    /*IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");
        // Wait for the animation to finish
        yield return new WaitForSeconds(transitionTime);
        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }*/
    void ChangeScene()
    { 
        if (!string.IsNullOrEmpty(SceneToPlay))
        {
            if (WithAnimation)
            {
                StartCoroutine(ChangeSceneWithAnimation());
            }
            else
            {
                SceneManager.LoadScene(SceneToPlay);
            }
        }
        else
        {
            Debug.LogError("SceneToPlay is not set");        
        }
    }

}

    // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));